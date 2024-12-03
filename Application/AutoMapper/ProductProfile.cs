using Application.Dtos.Product;
using Application.Features.Products.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
    }
}

