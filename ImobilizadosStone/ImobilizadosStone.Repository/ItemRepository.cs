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
        public ItemRepository(Settings settings) : base(settings, "Item")
        {
        }
    }
}
