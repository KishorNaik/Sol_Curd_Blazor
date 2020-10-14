using AutoMapper;
using ProductEntity = Product.FrontEnd.Models;
using ProductOpenApiEntity = Product.FrontEnd.OpenApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Mappers
{
    public class ProductModelMapperProfile : Profile
    {
        public ProductModelMapperProfile()
        {
            base.CreateMap<ProductEntity.ProductModel, ProductOpenApiEntity.ProductModel>();
            base.CreateMap<ProductOpenApiEntity.ProductModel, ProductEntity.ProductModel>();
        }
    }
}