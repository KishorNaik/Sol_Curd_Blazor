using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Cores.Repositories;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region EndPoint

        [HttpPost("add")]
        public async Task<bool> AddProductAsync([FromBody] ProductModel productModel, [FromServices] IAddProductRepository addProductRepository)
        {
            try
            {
                return await addProductRepository?.AddProductAsync(productModel);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("update")]
        public async Task<bool> UpdateProductAsync([FromBody] ProductModel productModel, [FromServices] IUpdateProductRepository updateProductRepository)
        {
            try
            {
                return await updateProductRepository?.UpdateProductAsync(productModel);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("delete")]
        public async Task<bool> DeleteProductAsync([FromBody] ProductModel productModel, [FromServices] IDeleteProductRepository deleteProductRepository)
        {
            try
            {
                return await deleteProductRepository?.DeleteProductAsync(productModel);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("getproducts")]
        public async Task<IEnumerable<ProductModel>> GetProductsAsync([FromServices] IGetProductsRepository getProductsRepository)
        {
            try
            {
                return await getProductsRepository?.GetProductsAsync();
            }
            catch
            {
                throw;
            }
        }

        #endregion EndPoint
    }
}