using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei.Lab3.Entities
{
    public class ShoppingCartEntity
    {
        public int Id { get; set; }

        public IdentityUser customer { get; set; }

        public int quantity { get; set; }

        public int productID { get; set; }
    }
}
