using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab3.Entities;
using Wsei.Lab3.Models;

namespace Wsei.Lab3.Services
{
    public interface IProductService
    {
        Task Add(ProductModel product);

        Task<IEnumerable<ProductEntity>> GetAll();
        Task<IEnumerable<ProductEntity>> GetAllOfUser();

        Task Delete(int id);

        Task DeleteFromCart(int id);

        Task<IEnumerable<ProductEntity>> GetByID(int id);
    }
}
