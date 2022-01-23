using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei.Lab3.Models
{
    public class ShoppingCartModel
    {
        public int quantity { get; set; }

        public int productID { get; set; }
    }
}
