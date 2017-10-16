using ImobilizadosStone.Resources;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ImobilizadosStone.Repository
{
    public abstract class RepositoryBase<T>
    {
        protected readonly IMongoCollection<T> Collection;

        public RepositoryBase(Settings settings, string collection)
        {
            //TODO: Singleton para MongoClient
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
            {
                var database = client.GetDatabase(settings.Database);

                Collection = database.GetCollection<T>(collection);
            }
        }

        public T Get(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
            var result = Collection.Find(filter).FirstOrDefault();
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.Find(t => true).ToEnumerable();
        }

        public void Insert(T entity)
        {
            Collection.InsertOne(entity);
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return Collection.AsQueryable().Where(expression);
        }

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = Collection.DeleteOne(filter);
        }

        public void Update(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);

            var result = Collection.ReplaceOne(filter, entity);
        }
    }
}
