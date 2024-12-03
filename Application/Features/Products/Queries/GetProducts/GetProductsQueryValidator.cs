using FluentValidation;

namespace Application.Features.Products.Queries.GetProducts;

public class GetCountriesQueryValidator : AbstractValidator<GetProductsQuery>
{
    public GetCountriesQueryValidator()
    {
    }
}
