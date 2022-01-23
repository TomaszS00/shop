using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab3.Entities;
using Wsei.Lab3.Models;

namespace Wsei.Lab3.Services
{
    public interface IShoppingService
    {
        Task Add(ShoppingCartModel shoppingCart);

        Task Remove(int id);

        Task Update(int id, int quantity);

        Task<IEnumerable<ShoppingCartEntity>> GetAll();

        
    }
}
