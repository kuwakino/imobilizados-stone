using ImobilizadosStone.Domain.Entities;
using ImobilizadosStone.Domain.Repository;
using ImobilizadosStone.Resources;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImobilizadosStone.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IOptions<Settings> settings) : base(settings, "Item")
        {
        }

        public void Delete(Item entity)
        {
            var filter = Builders<Item>.Filter.Eq("id", entity.Id);
            var result = Collection.DeleteOne(filter);
        }

        public void Update(Item entity)
        {
            var filter = Builders<Item>.Filter.Eq("id", entity.Id);
            var update = Builders<Item>.Update
                .Set("Name", entity.Name)
                .Set("Allocated", entity.Allocated)
                .Set("Enabled", entity.Enabled)
                .Set("Floor.Number", entity.Floor.Number)
                .Set("Floor.Building", entity.Floor.Building);
            var result = Collection.UpdateOne(filter, update);
        }
    }
}
