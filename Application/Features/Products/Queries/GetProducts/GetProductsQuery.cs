using Application.Common.Interfaces;
using Application.Dtos.Product;

namespace Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery : ITransactionRequest<List<ProductDto>>
{
}
