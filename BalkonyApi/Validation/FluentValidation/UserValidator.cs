using BalkonyEntity.DTO.User;
using FluentValidation;

namespace BalkonyApi.Validation.FluentValidation
{
    public class UserValidator:AbstractValidator<UserDTORequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı Adı Boş Olmamalıdır!!");
            RuleFor(x => x.Name).Length(2,50).WithMessage("Kullanıcı Adı En Az 2 Karakter Olmalıdır!!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Kullanıcı E-posta Adresi Boş Olamaz!!");
            RuleFor(x => x.Email).Matches("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$").WithMessage("E-Posta Formatı Doğru Değil!!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kullanıcı Şifresi Boş Olamaz!!");
            
        }
    }
}
