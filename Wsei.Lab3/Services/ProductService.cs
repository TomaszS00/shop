using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab3.Database;
using Wsei.Lab3.Entities;
using Wsei.Lab3.Models;

namespace Wsei.Lab3.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(AppDbContext dbContext, UserManager<IdentityUser> userManager, IHttpContextAccessor
       httpContextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Add(ProductModel product)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

           var entity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible,
                Owner = currentUser,
                Price = product.Price,
                //ProductImage = product.ProductImage
            };
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            IQueryable<ProductEntity> productsQuery = _dbContext.Products;
            var products = await productsQuery.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllOfUser()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<ProductEntity> productsQuery = _dbContext.Products;

            productsQuery = productsQuery.Where(x => x.Owner == currentUser);

            var products = await productsQuery.ToListAsync();
            return products;
        }

        public async Task Delete(int id)
        {
            var toDelete = _dbContext.Products.First(x => x.Id == id);
            if (toDelete != null)
            {
                _dbContext.Products.Remove(toDelete);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFromCart(int id)
        {
            return;
        }

        public async Task<IEnumerable<ProductEntity>> GetByID(int id)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<ProductEntity> productsQuery = _dbContext.Products;

            productsQuery = productsQuery.Where(x => x.Id == id);

            var products = await productsQuery.ToListAsync();
            return products;
        }
    }
}
