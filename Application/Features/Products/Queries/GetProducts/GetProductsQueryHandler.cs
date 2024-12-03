using Application.Dtos.Product;
using AutoMapper;
using Domain.Entities.Products;
using Framework.Api;
using MediatR;
using Persistence.Repositories;
using System.Reflection;

namespace Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IEFRepositories<Product> _productRepository;
    private readonly IMapper _mapper;
    public GetProductsQueryHandler(IEFRepositories<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var listProducts = await _productRepository.GetAllAsync(cancellationToken);
            var result = _mapper.Map<List<ProductDto>>(listProducts);
            return result;
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            throw new ApplicationException(msg, ex);
        }
    }
}
