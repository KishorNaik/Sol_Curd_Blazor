using Api.Cores.Repositories;
using Api.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations
{
    public static class RepositoriesServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAddProductRepository, AddProductRepository>();
            services.AddTransient<IUpdateProductRepository, UpdateProductRepository>();
            services.AddTransient<IDeleteProductRepository, DeleteProductRepository>();
            services.AddTransient<IGetProductsRepository, GetProductsRepository>();
        }
    }
}