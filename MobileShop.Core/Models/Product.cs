using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string SizeScreen { get; set; }
        public string Weight { get; set; }
        public string Camera { get; set; }
        public string RAM { get; set; }
        public string Memory { get; set; }
        public string Image { get; set; }
        public string OS { get; set; }
        public string Battery { get; set; }
        public string Sim { get; set; }
        public string PhuKien { get; set; }
        public string BaoHanh { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get;set; }
    }
}
