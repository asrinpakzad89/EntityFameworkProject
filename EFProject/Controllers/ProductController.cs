using Application.Dtos.Product;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Queries.GetProducts;
using Framework.Api;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EFProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize("User")]
    public async Task<ApiResult<List<ProductDto>>> GetAllProducts()
    {
        var query = new GetProductsQuery();
        return await _mediator.Send(query);
    }

    [Authorize]
    [HttpPost]
    public async Task<ApiResult> CreateProduct(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
