using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;
using MobileShop.Web.Models;
using NuGet.Common;
using System.Net;
using System.Security.Policy;

namespace MobileShop.Web.Controllers
{
    public class PaymenController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<IdentityUser> userManager;

        public PaymenController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        [HttpPost]
        public IActionResult Payment(string totalMoney, string pthuc)
        {
            string vnp_Returnurl = "http://localhost:5000/Paymen/ReturnData";
            string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
            string vnp_TmnCode = "Q89YG6GI";
            string vnp_HashSecret = "WAQHVVXMLCNATDQGKEDDVLULBPNBXXZD";
            
            var money = totalMoney.Split('.');
            //Get payment input
            OrderInfo order = new OrderInfo();
            //Save order to db
            order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            order.Amount = long.Parse(money[0]); // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
            order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending"
            order.OrderDesc = "";
            order.CreatedDate = DateTime.Now;
            string locale = "vn";
            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();
            var ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if(ip == "::1")
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không 
            vnpay.AddRequestData("vnp_BankCode", pthuc);
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", ip);
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "billpayment"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());
            
            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            //log.InfoFormat("VNPAY URL: {0}", paymentUrl);

            return Redirect(paymentUrl);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnData(ResponseDataVnPay data)
        {
            if (data.vnp_TransactionStatus == "00")
            {
                var shopUser = await userManager.GetUserAsync(User);
                var userCart = unitOfWork.UserCartRepository.GetByWhereAsync(x => x.UserId == shopUser.Id).ToList();
                Order order = new Order()
                {
                    UserId = shopUser.Id,
                    Address = "Hưng Yên",
                    DateOrder = DateTime.Now,
                    TotalPrice = userCart.Sum(x => x.Subtotal),
                    OrderStatus = "Đang giao hàng"
                };
                await unitOfWork.OrderRepository.CreateAsync(order);
                foreach (var item in userCart)
                {
                    OrderDetail detail = new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    await unitOfWork.OrderDetailRepository.CreateAsync(detail);
                    var product = await unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                    product.Quantity = product.Quantity - item.Quantity;
                    unitOfWork.SaveChange();
                }
                var allCart = await unitOfWork.UserCartRepository.GetAllAsync();
                foreach (var item in allCart)
                {
                    if(item.UserId == shopUser.Id)
                    {
                        await unitOfWork.UserCartRepository.Deletesync(item);
                    }    
                }
                return Redirect("/product/");
            }
            else
            {
                return BadRequest();
            }
        }
            
    }
}
