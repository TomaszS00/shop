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
using Newtonsoft.Json;

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

            return View(product);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List(string name = "")
        {
            var products = await _productService.GetAllOfUser();
            if(name != null)
            {
                return View(products.Where(p => p.Name.ToLower().Contains(name.ToLower()) || p.Description.ToLower().Contains(name.ToLower())));
            } 
            else
            {
                return View(products);
            }
        }

        [HttpGet]
        public async Task<IActionResult> availableProducts()
        {
            var products = await _productService.GetAll();
            return View(products.Where(p => p.IsVisible));
        }

        [HttpGet]
        public async Task<IActionResult> description(int id)
        {
            var products = await _productService.GetByID(id);
            return View(products);
        }

        public async Task<IActionResult> Delete([FromBody] ProductDeleteModel request)
        {
            await _productService.Delete(request.id);
            return Json("XXX");
        }

        public async Task<IActionResult> DeleteFromCart([FromBody] ProductDeleteModel request)
        {
            await _shoppingServices.Remove(request.id);
            return Json("XXX");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ShoppingCart()
        {
            IEnumerable<ShoppingCartEntity> shoppingCart = await _shoppingServices.GetAll();
            List<ShoppingCartViewModel> products = new List<ShoppingCartViewModel> { };
            foreach(ShoppingCartEntity v in shoppingCart)
            {
                int id = v.productID;
                IEnumerable<ProductEntity> pid = await _productService.GetByID(id);
                if(pid.Count() > 0)
                {
                    var x = new ShoppingCartViewModel { Id = v.Id, quantity = v.quantity, product = pid.ElementAt(0) };
                    products.Add(x);
                }
            }
            return View(products);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Order()
        {
            IEnumerable<ShoppingCartEntity> shoppingCart = await _shoppingServices.GetAll();
            foreach (ShoppingCartEntity v in shoppingCart)
            {
                await _shoppingServices.Remove(v.Id);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart([FromBody] ShoppingCartModel request)
        {
            ShoppingCartModel shoppingCart = new ShoppingCartModel
            {
            quantity = request.quantity,
            productID = request.productID
            };
            await _shoppingServices.Add(shoppingCart);

            return Json("XXX");
        }

    }
}
