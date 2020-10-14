using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Cores.Repositories
{
    public interface IDeleteProductRepository
    {
        Task<bool> DeleteProductAsync(ProductModel productModel);
    }
}