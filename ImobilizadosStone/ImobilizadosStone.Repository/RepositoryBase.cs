using ImobilizadosStone.Domain.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using ImobilizadosStone.Resources;
using System.Linq.Expressions;

namespace ImobilizadosStone.Repository
{
    public abstract class RepositoryBase<T>
    {
        protected readonly IMongoCollection<T> Collection;

        public RepositoryBase(IOptions<Settings> settings, string collection)
        {
            //TODO: Singleton para MongoClient
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                var database = client.GetDatabase(settings.Value.Database);

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
    }
}
