using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autospace2.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Schedule { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<ProductShop> ProductShops { get; set; } = new List<ProductShop>();
    }
}
