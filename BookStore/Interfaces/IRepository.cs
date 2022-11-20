using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        bool SaveAll();
    }
}