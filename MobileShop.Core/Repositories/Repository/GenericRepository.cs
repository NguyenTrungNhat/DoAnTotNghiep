using Microsoft.EntityFrameworkCore;
using MobileShop.Core.Data;
using MobileShop.Core.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly MobileShopDBContext context;
        protected DbSet<TEntity> entities;
        public GenericRepository() 
        {
            context = new MobileShopDBContext();
            entities = context.Set<TEntity>();
        }

        public GenericRepository(MobileShopDBContext _context)
        {
            context = _context;
            entities = _context.Set<TEntity>();
        }

        public async void SaveChangeAsync()
        {
            this.context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Deletesync(TEntity entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> GetByWhereAsync(Func<TEntity, bool> predicate)
        {
            return entities.Where(predicate).AsQueryable().AsNoTracking();
        }
    }
}
