using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab3.Database;
using Wsei.Lab3.Entities;
using Wsei.Lab3.Models;

namespace Wsei.Lab3.Services
{
    public class ShoppingServices : IShoppingService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingServices(AppDbContext dbContext, UserManager<IdentityUser> userManager, IHttpContextAccessor
       httpContextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Add(ShoppingCartModel shoppingCart)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        

        var entity = new ShoppingCartEntity
            {

                customer = currentUser,
                quantity = shoppingCart.quantity,
                productID = shoppingCart.productID
                
                //ProductImage = product.ProductImage
            };
            Console.WriteLine(JsonConvert.SerializeObject(entity) ); 
            Console.WriteLine(entity);
            await _dbContext.ShoppingCart.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task Update(int id, int quantity)
        {
            var x = await _dbContext.ShoppingCart.FindAsync(id);
            x.quantity = quantity;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var x = await _dbContext.ShoppingCart.FindAsync(id);
            _dbContext.ShoppingCart.Remove(x);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingCartEntity>> GetAll()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<ShoppingCartEntity> shoppingQuery = _dbContext.ShoppingCart;

            shoppingQuery = shoppingQuery.Where(x => x.customer == currentUser);



            List<ShoppingCartEntity> shoppingQ = await shoppingQuery.ToListAsync();
            return shoppingQ;
        }

        

    }
}
