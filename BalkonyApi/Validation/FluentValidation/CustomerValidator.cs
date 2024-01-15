using BalkonyEntity.DTO.Customer;
using FluentValidation;

namespace BalkonyApi.Validation.FluentValidation
{
    public class CustomerValidator:AbstractValidator<CustomerDTORequest>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Müşteri Adı Boş Olamaz!!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Müşteri Adı En Az 3 karakter Olmalıdır!!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Müşteri Numarası Boş Olamaz!!");
            RuleFor(x => x.Phone).Length(15,15).WithMessage("Müşteri Numarası Eksik Girildi!!");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Müşterinin Adresi Boş Olamaz!!");
        }
    }
}
