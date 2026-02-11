using System.Linq.Expressions;
using MongoDB.Driver;

namespace Infrastructure.mongodb.Repository
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> Collection => _collection;

        public async Task CreateAsync(T entity) => 
            await _collection.InsertOneAsync(entity);

         public async  Task CreateManyAsync(IEnumerable<T> entities)
        {
            // Kiểm tra null hoặc rỗng để tránh lỗi driver
            if (entities == null || !entities.Any()) 
            {
                return;
            }

            // Gọi hàm gốc của Mongo Driver
            await _collection.InsertManyAsync(entities);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null) =>
            filter == null 
                ? await _collection.Find(_ => true).ToListAsync() 
                : await _collection.Find(filter).ToListAsync();

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter) =>
            await _collection.Find(filter).FirstOrDefaultAsync();

        public async Task UpdateAsync(Expression<Func<T, bool>> filter, T entity) =>
            await _collection.ReplaceOneAsync(filter, entity);

        public async Task UpsertAsync(Expression<Func<T, bool>> filter, T entity)
        {
            var options = new ReplaceOptions { IsUpsert = true };
            await _collection.ReplaceOneAsync(filter, entity, options);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> filter) =>
            await _collection.DeleteOneAsync(filter);

       
    }
}