using AutoMapper;
using Comp.ProductManagement.Application.DTOs.Product;
using Comp.ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
