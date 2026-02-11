using System.Linq.Expressions;
using MongoDB.Driver;

namespace Infrastructure.mongodb.Repository
{
    public interface IMongoRepository<T> where T : class
    {
        IMongoCollection<T> Collection { get; }

        // CREATE
        Task CreateAsync(T entity);
        Task CreateManyAsync(IEnumerable<T> entities);

        // READ
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);

        // UPDATE
        Task UpdateAsync(Expression<Func<T, bool>> filter, T entity);

        // UPSERT
        Task UpsertAsync(Expression<Func<T, bool>> filter, T entity);

        // DELETE
        Task DeleteAsync(Expression<Func<T, bool>> filter);
    }
}