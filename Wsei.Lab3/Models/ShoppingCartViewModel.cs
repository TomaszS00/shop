using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab3.Entities;

namespace Wsei.Lab3.Models
{
    public class ShoppingCartViewModel
    {
        public int quantity { get; set; }

        public int Id { get; set; }
        public ProductEntity product { get; set; }
    }
}
