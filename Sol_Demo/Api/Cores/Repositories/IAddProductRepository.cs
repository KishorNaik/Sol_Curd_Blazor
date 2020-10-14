using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Cores.Repositories
{
    public interface IAddProductRepository
    {
        Task<bool> AddProductAsync(ProductModel productModel);
    }
}