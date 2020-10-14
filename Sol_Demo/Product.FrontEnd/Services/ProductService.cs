using ProductEntity = Product.FrontEnd.Models;
using ProductOpenApiEntity = Product.FrontEnd.OpenApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;

namespace Product.FrontEnd.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly HttpClient httpClient = null;
        private readonly IMapper mapper = null;

        public ProductService(HttpClient httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            this.mapper = mapper;
        }

        async Task<bool> IProductService.AddProductApiAsync(ProductEntity.ProductModel productModel)
        {
            try
            {
                var swaggerClient = new ProductOpenApiEntity.swaggerClient(httpClient.BaseAddress.AbsoluteUri, httpClient);

                var mapperOpenApiProductModel = mapper.Map<ProductOpenApiEntity.ProductModel>(productModel);

                var flag = await swaggerClient.AddAsync(mapperOpenApiProductModel);

                return flag;
            }
            catch
            {
                throw;
            }
        }

        async Task<bool> IProductService.DeleteProductApiAsync(ProductEntity.ProductModel productModel)
        {
            try
            {
                var swaggerClient = new ProductOpenApiEntity.swaggerClient(httpClient.BaseAddress.AbsoluteUri, httpClient);

                var mapperOpenApiProductModel = mapper.Map<ProductOpenApiEntity.ProductModel>(productModel);

                var flag = await swaggerClient.DeleteAsync(mapperOpenApiProductModel);

                return flag;
            }
            catch
            {
                throw;
            }
        }

        async Task<IEnumerable<ProductEntity.ProductModel>> IProductService.GetProductsAsync()
        {
            try
            {
                var swaggerClient = new ProductOpenApiEntity.swaggerClient(httpClient.BaseAddress.AbsoluteUri, httpClient);

                var data = (await swaggerClient.GetproductsAsync()).ToList();

                var mapProductList = mapper.Map<List<ProductEntity.ProductModel>>(data);

                return mapProductList;
            }
            catch
            {
                throw;
            }
        }

        async Task<bool> IProductService.UpdateProductApiAsync(ProductEntity.ProductModel productModel)
        {
            try
            {
                var swaggerClient = new ProductOpenApiEntity.swaggerClient(httpClient.BaseAddress.AbsoluteUri, httpClient);

                var mapperOpenApiProductModel = mapper.Map<ProductOpenApiEntity.ProductModel>(productModel);

                var flag = await swaggerClient.UpdateAsync(mapperOpenApiProductModel);

                return flag;
            }
            catch
            {
                throw;
            }
        }
    }
}