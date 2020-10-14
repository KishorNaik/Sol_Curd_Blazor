using Product.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.Services
{
    public interface IProductService
    {
        Task<bool> AddProductApiAsync(ProductModel productModel);

        Task<bool> UpdateProductApiAsync(ProductModel productModel);

        Task<bool> DeleteProductApiAsync(ProductModel productModel);

        Task<IEnumerable<ProductModel>> GetProductsAsync();
    }
}