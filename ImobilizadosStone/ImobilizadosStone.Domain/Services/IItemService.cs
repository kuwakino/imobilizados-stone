using ImobilizadosStone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImobilizadosStone.Domain.Services
{
    public interface IItemService
    {
        Item GetById(string id);
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetAllAllocatedByFloor(int floorNumber, string building);
        IEnumerable<Item> GetAllAllocated();
        IEnumerable<Item> GetAllNotAllocated();
        void Add(Item item);
        void Update(string id, Item item);
        bool Disable(string id);
        bool Enable(string id);
        void Delete(string id);

        bool Use(string id, Floor floor);
    }
}
