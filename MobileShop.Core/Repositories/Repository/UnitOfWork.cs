using MobileShop.Core.Data;
using MobileShop.Core.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MobileShopDBContext context;
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;
        private IUserRepository userRepository;
        private IUserCartRepository userCartRepository;

        public UnitOfWork()
        {
            context= new MobileShopDBContext();
        }
        public MobileShopDBContext MobileShopDBContext
        {
            get 
            {
                return context; 
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if(categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(context);
                }
                return orderRepository;
            }
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                if(orderDetailRepository == null)
                {
                    orderDetailRepository = new OrderDetailRepository(context);
                }
                return orderDetailRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }    
                return userRepository;
            }
        }

        public IUserCartRepository UserCartRepository
        {
            get
            {
                if (userCartRepository == null)
                {
                    userCartRepository = new UserCartRepository(context);
                }
                return userCartRepository;
            }
        }
        public void Dispose()
        {
            this.context.Dispose();
        }

        public int SaveChange()
        {
            return this.context.SaveChanges();
        }

        public Task<int> SaveChangeAsync()
        {
            return this.context.SaveChangesAsync();
        }
    }
}
