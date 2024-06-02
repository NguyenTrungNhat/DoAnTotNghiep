namespace MobileShop.Web.Areas.Admin.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime DateOrder { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }
    }
}
