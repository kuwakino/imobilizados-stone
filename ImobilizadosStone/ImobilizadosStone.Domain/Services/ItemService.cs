using System.Collections.Generic;
using ImobilizadosStone.Domain.Entities;
using ImobilizadosStone.Domain.Repository;

namespace ImobilizadosStone.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
                
        public Item GetById(string id)
        {
            return _itemRepository.Get(id);
        }

        public IEnumerable<Item> GetAllAllocatedByFloor(int floorNumber, string building)
        {
            return _itemRepository.GetByExpression(i => i.Enabled && 
                                                        i.Floor!=null && 
                                                        i.Floor.Number == floorNumber && 
                                                        i.Floor.Building == building);
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public void Add(Item item)
        {
            _itemRepository.Insert(item);
        }

        public bool Disable(string id)
        {
            var itemBase = GetById(id);
            itemBase.Enabled = false;
            Update(id, itemBase);
            return !itemBase.Enabled;
        }

        public void Update(string id, Item item)
        {
            item.Id = id;
            _itemRepository.Update(id, item);
        }

        public bool Enable(string id)
        {
            var itemBase = GetById(id);
            itemBase.Enabled = true;
            Update(id, itemBase);
            return itemBase.Enabled;
        }

        public void Delete(string id)
        {
            _itemRepository.Delete(id);
        }

        public bool Use(string id, Floor floor)
        {
            var itemBase = GetById(id);
            if (itemBase.Enabled && !itemBase.Allocated)
            {
                itemBase.Floor = floor;
                Update(id, itemBase);

                return true;
            }
            else
                return false;
        }
    }
}