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
        private readonly IShoppingService _shoppingServices;

        public ProductsController(IProductService productService, IShoppingService shoppingService)
        {
            _productService = productService;
            _shoppingServices = shoppingService;
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
                Price = product.Price,
                //ProductImage = product.ProductImage
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> availableProducts()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> description(int id)
        {
            var products = await _productService.GetByID(id);
            return View(products);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ShoppingCart()
        {
            var products = await _shoppingServices.GetAll();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(int productid, int quantity)
        {

            ShoppingCartModel shoppingCart = new ShoppingCartModel
            {
                quantity = quantity,
                productID = productid
            };
            await _shoppingServices.Add(shoppingCart);
           
            return View();
        }

    }
}
