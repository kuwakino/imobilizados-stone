using System.Collections.Generic;
using ImobilizadosStone.Domain.Entities;
using ImobilizadosStone.Domain.Repository;

namespace ImobilizadosStone.Domain.Services
{
    public class ItemService : IItemService
    {
        IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Add(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void Disable(Item item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> GetAllAllocated()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> GetAllByFloor(int FloorNumber, string Building)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> GetAllNotAllocated()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}