using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab3.Database;
using Wsei.Lab3.Entities;
using Wsei.Lab3.Models;
using Wsei.Lab3.Services;
using Microsoft.AspNetCore.Authorization;

namespace Wsei.Lab3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(ProductModel product)
        {
            await _productService.Add(product);

            var viewModel = new ProductStatsViewModel
            {
                NameLength = product.Name.Length,
                DescriptionLength = product.Description.Length,
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List(string name)
        {
            var products = await _productService.GetAll(name);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> availableProducts(string name)
        {
            var products = await _productService.GetAll(name);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> description(string name)
        {
            var products = await _productService.GetAll(name);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShoppingCart(string name)
        {
            var products = await _productService.GetAll(name);
            return View(products);
        }

    }
}
