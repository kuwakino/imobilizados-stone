using ImobilizadosStone.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ImobilizadosStone.Domain.Entities;
using System.Linq.Expressions;
using ImobilizadosStone.Domain.Services;

namespace ImobilizadosStone.Domain.Test.Service
{
    //TODO: alternartiva usar biblioteca para mocks (ex.: Moq)
    public class MockItemRepository : IItemRepository
    {
        public Item _itemGet;

        public MockItemRepository(Item itemGet)
        {
            _itemGet = itemGet;
        }
        
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Item Get(string id)
        {
            return _itemGet;
        }

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetByExpression(Expression<Func<Item, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Insert(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Item entity)
        {

        }
    }

    public class ItemServiceTest
    {
        [Fact]
        private void GivenItemAllocated_WhenUse_ThenFalseToUse()
        {
            var item = new Item
            {
                Id = "ItemEmUso",
                Name = "stn-2017-0001 Dell i13-7348-v40",
                Enabled = true,
                Floor = new Floor
                {
                    Number = 1,
                    Building = "Ed. Stone",
                }
            };

            var floor2 = new Floor
            {
                Number = 2,
                Building = "Ed. Stone",
            };

            var service = new ItemService(new MockItemRepository(item));
            var resultAct = service.Use(item.Id, floor2);
            Assert.False(resultAct);
        }

        [Fact]
        private void GivenItemNotAllocatedAndEnabled_WhenUse_ThenTrueToUse()
        {
            var item = new Item
            {
                Id = "ItemLivre",
                Name = "stn-2017-0002 Dell i13-7348-v40",
                Enabled = true                
            };

            var floor2 = new Floor
            {
                Number = 2,
                Building = "Ed. Stone",
            };

            var service = new ItemService(new MockItemRepository(item));
            var resultAct = service.Use(item.Id, floor2);
            Assert.True(resultAct);
        }

        [Fact]
        private void GivenItemNotAllocatedAnDisabled_WhenUse_ThenFalseToUse()
        {
            var item = new Item
            {
                Id = "ItemDesabilitado",
                Name = "stn-2017-0003 Dell i13-7348-v40",
                Enabled = false
            };

            var floor2 = new Floor
            {
                Number = 2,
                Building = "Ed. Stone",
            };

            var service = new ItemService(new MockItemRepository(item));
            var resultAct = service.Use(item.Id, floor2);
            Assert.False(resultAct);
        }
    }
}
