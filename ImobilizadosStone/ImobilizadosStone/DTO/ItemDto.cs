using ImobilizadosStone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobilizadosStone.WebAPI.DTO
{
    public class ItemDto
    {

        public ItemDto() { }
        
        public ItemDto(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Enabled = item.Enabled;
            Allocated = item.Allocated;

            if(item.Floor != null)
                Floor = new FloorDto(item.Floor);
        }

        public string Id { get; set; }

        public string Name { get; set; }
        public bool Allocated { get; set; }
        public bool Enabled { get; set; }

        public FloorDto Floor { get; set; }
    }

    public class FloorDto
    {
        public FloorDto() { }
               
        public FloorDto(Floor floor)
        {
            Number = floor.Number;
            Building = floor.Building;
        }

        public int Number { get; set; }
        public string Building { get; set; }
    }
}
