using System;
using System.Collections.Generic;
using System.Text;

namespace ImobilizadosStone.Domain.Entities
{
    public class Item
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public bool Allocated { get; set; }
        public bool Enabled { get; set; }

        public Floor Floor { get; set; }        
    }

    public class Floor
    {
        public int Number { get; set; }
        public string Building { get; set; }
    }
}
