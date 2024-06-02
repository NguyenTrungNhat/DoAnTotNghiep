using Microsoft.AspNetCore.Identity;
using MobileShop.Core.Data;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.Repository
{
    public class UserRepository : GenericRepository<IdentityUser>, IUserRepository
    {
        public UserRepository()
        { }

        public UserRepository(MobileShopDBContext context) : base(context)
        {
        }

        public IdentityUser GetById(string id)
        {
            var user = entities.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }
    }
}
