using BalkonyEntity.DTO.Login;
using FluentValidation;

namespace BalkonyApi.Validation.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginDTORequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail Alanı Boş Geçilemez!!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Alanı Boş Geçilemez!!");
        }
    }
}
