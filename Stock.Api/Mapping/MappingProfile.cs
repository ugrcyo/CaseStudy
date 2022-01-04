using System;
using System.Collections.Generic;
using AutoMapper;
using Stock.Api.DTO;
using Stock.Core.Models;

namespace Stock.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockInfo,StockDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Variant, VariantDTO>();
            CreateMap<Size, SizeDTO>();
            CreateMap<Color, ColorDTO>();

            CreateMap<StockDTO, StockInfo>();
            CreateMap<ProductDTO, Product>();
            CreateMap<VariantDTO, Variant>();
            CreateMap<SizeDTO, Size>();
            CreateMap<ColorDTO, Color>();
        }
    }
}
