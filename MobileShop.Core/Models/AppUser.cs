using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
        public virtual UserCart UserCart { get; set; }
    }
}
