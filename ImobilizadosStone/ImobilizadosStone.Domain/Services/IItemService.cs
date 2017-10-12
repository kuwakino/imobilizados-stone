using ImobilizadosStone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImobilizadosStone.Domain.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllAllocated();
        IEnumerable<Item> GetAllNotAllocated();
        IEnumerable<Item> GetAllByFloor(int FloorNumber, string Building);
        void Add(Item item);
        void Update(Item item);
        void Disable(Item item);
    }
}
