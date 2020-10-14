using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Product.FrontEnd.OpenApi;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd
{
    public static class Startup
    {
        public static void ProductConfigureService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddHttpClient<IProductService, ProductService>((config) =>
            {
                config.BaseAddress = new Uri("http://localhost:1771/");
            });
        }
    }
}