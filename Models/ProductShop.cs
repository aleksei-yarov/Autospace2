using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Autospace2.Models
{
    public class ProductShop
    {
        public int ProductId { get; set; }
        public int ShopId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
    }
}
