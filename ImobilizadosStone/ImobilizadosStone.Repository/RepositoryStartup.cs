using ImobilizadosStone.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImobilizadosStone.Repository
{
    public class RepositoryStartup
    {
        public static void Initialize()
        {
            BsonClassMap.RegisterClassMap<Item>(i =>
            {
                i.AutoMap();
                i.MapIdProperty(e => e.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}
