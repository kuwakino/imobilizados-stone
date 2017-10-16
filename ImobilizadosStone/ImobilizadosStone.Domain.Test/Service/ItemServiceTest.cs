using ImobilizadosStone.Domain.Entities;
using ImobilizadosStone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImobilizadosStone.Domain.Test.Service
{
    public class ItemServiceTest
    {
        private readonly IItemService _itemService;

        public ItemServiceTest(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void SeedTest()
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

            _itemService.Add(new Item
            {
                Name = "stn-2017-0001 Dell i13-7348-v40",
                Enabled = true,
                Floor = floor1
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0002 Dell i13-7348-v40",
                Enabled = true,
                Floor = floor1
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0003 Samsung S24E310",
                Enabled = true,
                Floor = floor1
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0004 Samsung S24E310",
                Enabled = true,
                Floor = floor1
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0005 Dell i13-7348-v40",
                Enabled = true,
                Floor = floor2
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0006 Samsung S24E310",
                Enabled = true,
                Floor = floor2
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0007 Dell i13-7348-v40",
                Enabled = true,
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0008 Dell i13-7348-v40",
                Enabled = true,
            });

            _itemService.Add(new Item
            {
                Name = "stn-2017-0009 Dell i13-7348-v40",
                Enabled = false,
            });
        }
    }
}
