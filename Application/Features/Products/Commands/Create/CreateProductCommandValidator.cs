using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Title)
          .NotEmpty().WithMessage("عنوان محصول نباید خالی باشد.");

        RuleFor(p => p.Price)
            .GreaterThan(300).WithMessage("قیمت محصول نباید کمتر از 300 دلار باشد.");
    }
}
