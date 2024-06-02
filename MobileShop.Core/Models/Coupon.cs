using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public decimal CouponAmount { get; set; }
    }
}
