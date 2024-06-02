using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DateOrder { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
