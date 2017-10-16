using ImobilizadosStone.Domain.Entities;
using ImobilizadosStone.Domain.Services;
using ImobilizadosStone.Repository;
using ImobilizadosStone.Resources;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Xunit;

namespace ImobilizadosStone.Domain.Test.Service
{
    public class MongoFixture : IDisposable
    {
        public IItemService ItemService { get; set; }

        private Settings mongoSettings;

        public MongoFixture()
        {
            ImobilizadosStone.Repository.RepositoryStartup.Initialize();

            mongoSettings = new Settings
            {
                ConnectionString = "mongodb://127.0.0.1:27017",
                Database = "ItemServiceTestDB",
            };

            ItemService = new ItemService(new ItemRepository(mongoSettings));
        }

        public void Dispose()
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            client.DropDatabase(mongoSettings.Database);
        }
    }
    public class ItemServiceCRUDTest : IClassFixture<MongoFixture>
    {
        private readonly IItemService _itemService;
       
        public ItemServiceCRUDTest(MongoFixture mongoFixture)
        {
            _itemService = mongoFixture.ItemService;            
        }

        public static IEnumerable<object[]> SeedData()
        {
            var floor1 = new Floor
            {
                Number = 1,
                Building = "Ed. Stone",
            };

            var floor2 = new Floor
            {
                Number = 2,
                Building = "Ed. Stone",
            };

            var seedData = new List<object[]>();

            seedData.Add( new object[] { new Item { Name = "stn-2017-0001 Dell i13-7348-v40", Enabled = true, Floor = floor1 } });
            seedData.Add(new object[] { new Item { Name = "stn-2017-0002 Dell i13-7348-v40", Enabled = true, Floor = floor1 } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0003 Samsung S24E310", Enabled = true, Floor = floor1 } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0004 Samsung S24E310", Enabled = true, Floor = floor1 } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0005 Dell i13-7348-v40", Enabled = true, Floor = floor2 } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0006 Samsung S24E310", Enabled = true, Floor = floor2 } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0007 Dell i13-7348-v40", Enabled = true } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0008 Dell i13-7348-v40", Enabled = true } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0009 Dell i13-7348-v40", Enabled = false } });
            seedData.Add( new object[] { new Item { Name = "stn-2017-0010 Dell v14t-5470-a50", Enabled = false } });
            return seedData;
        }
        
        [Theory]
        [MemberData(nameof(SeedData))]
        private void GivenNewItem_WhenInserted_ThenItemPersisted(Item item)
        {
            _itemService.Add(item);
            _itemService.GetById(item.Id);
            Assert.True(!string.IsNullOrEmpty(item.Id));
        }

        [Theory]
        [MemberData(nameof(SeedData))]
        private void GivenItem_WhenUpdated_ThenItemPersisted(Item item)
        {
            _itemService.Add(item);
            item = _itemService.GetById(item.Id);
            item.Name += " UPDATED";
            _itemService.Update(item.Id, item);
            item = _itemService.GetById(item.Id);
            
            Assert.Contains("UPDATED", item.Name);
        }

        [Theory]
        [MemberData(nameof(SeedData))]
        private void GivenItem_WhenDeleted_ThenItemNotFound(Item item)
        {
            _itemService.Add(item);
            _itemService.Delete(item.Id);
            item = _itemService.GetById(item.Id);

            Assert.Null(item);
        }
    }
}
