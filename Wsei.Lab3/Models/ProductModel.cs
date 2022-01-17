using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei.Lab3.Models
{
    public class ProductModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsVisible { get; set; }

        public IFormFile ProductImage { get; set; }
    }
}
