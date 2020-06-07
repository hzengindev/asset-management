using Core.Utilities.Localizations;
using Entities.Dtos.Auth;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SignInDtoValidator : AbstractValidator<SignInDto>
    {
        public SignInDtoValidator()
        {
            RuleFor(z => z.Email).NotEmpty().WithMessage(TextCode.EmailIsEmpty.GetText()).WithErrorCode(((int)TextCode.EmailIsEmpty).ToString());
            RuleFor(z => z.Email).NotEmpty().WithMessage(TextCode.PasswordIsEmpty.GetText()).WithErrorCode(((int)TextCode.PasswordIsEmpty).ToString());
        }
    }
}