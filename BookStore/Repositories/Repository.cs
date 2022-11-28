using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Context;
using BookStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _set;

        protected Repository(ApplicationContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id).AsTask();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public void CreateAsync(TEntity entity)
        {
            _set.AddAsync(entity);
        }


        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }
        
        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }
        
        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}