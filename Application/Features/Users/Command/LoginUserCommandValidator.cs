using FluentValidation;

namespace Application.Features.Users.Command;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(o => o.Username)
            .NotEmpty().WithMessage("نام کاربری را وارد نمایید.");

        RuleFor(o => o.Password)
            .NotEmpty().WithMessage("رمز عبور را وارد نمایید.");
    }
}
