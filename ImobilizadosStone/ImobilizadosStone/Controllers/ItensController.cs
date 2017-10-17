using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImobilizadosStone.Domain.Services;
using ImobilizadosStone.WebAPI.DTO;
using ImobilizadosStone.Domain.Entities;

namespace ImobilizadosStone.WebAPI.Controllers
{
    [Route("api/itens")]
    public class ItensController : Controller
    {
        private readonly IItemService _itemService;

        public ItensController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET api/itens
        [HttpGet]
        public IEnumerable<ItemDto> Get([FromQuery] bool? allocated, [FromQuery] int? floorNumber, [FromQuery] string buildingName)
        {
            if (floorNumber.HasValue)
            {
                if (!allocated.HasValue || allocated.HasValue && allocated.Value)
                    return _itemService.GetAllAllocatedByFloor(floorNumber.Value, buildingName).Select(i => new ItemDto(i));
                else
                    return new List<ItemDto>();
            }
            else
            {
                if (allocated.HasValue)
                    if (allocated.Value)
                        return _itemService.GetAllAllocated().Select(i => new ItemDto(i));
                    else
                        return _itemService.GetAllNotAllocated().Select(i => new ItemDto(i));
            }
                        
            return _itemService.GetAll().Select(i => new ItemDto(i)); //!allocated.HasValue && !floorNumber.HasValue
        }

        // GET api/itens/{id}
        [HttpGet("{id}")]
        public ItemDto Get(string id)
        {
            return new ItemDto(_itemService.GetById(id));
        }

        // POST api/itens
        [HttpPost]
        public void Post([FromBody]ItemDto value)
        {
            var i = new Item();
            i.Name = value.Name;
            i.Enabled = true;

            if (value.Floor != null)
            {
                i.Floor = new Floor
                {
                    Number = value.Floor.Number,
                    Building = value.Floor?.Building,
                };
            }

            _itemService.Add(i);
        }

        // PUT api/itens/{id}
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]ItemDto value)
        {
            if (value == null || value.Id != id) //TODO: tratamento de exceção incluído apenas para informação ao cliente da API, necessita padronização
                throw new Exception("Invalid item. Check Item data or id.");

            var i = new Item();
            i.Name = value.Name;
            i.Enabled = value.Enabled;

            if (value.Floor != null)
            {
                i.Floor = new Floor
                {
                    Number = value.Floor.Number,
                    Building = value.Floor?.Building,
                };
            }

            _itemService.Update(id, i);
        }

        // PUT api/itens/{id}/use
        [HttpPut("{id}/use")]
        public bool Use(string id, [FromBody]FloorDto floor)
        {
            var f = new Floor();
            f.Number = floor.Number;
            f.Building = floor.Building;

            return _itemService.Use(id, f);
        }

        [HttpPut("{id}/enable")]
        public bool Enable(string id)
        {
            return _itemService.Enable(id);
        }

        [HttpPut("{id}/disable")]
        public bool Disable(string id)
        {
            return _itemService.Disable(id);
        }

        // DELETE api/itens/{id}
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _itemService.Delete(id);
        }
    }
}
