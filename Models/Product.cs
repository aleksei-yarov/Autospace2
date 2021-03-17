using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autospace2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();
        public List<ProductShop> ProductShops { get; set; } = new List<ProductShop>();
    }
}
