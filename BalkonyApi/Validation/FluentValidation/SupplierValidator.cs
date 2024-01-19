using BalkonyEntity.DTO.Supplier;
using FluentValidation;

namespace BalkonyApi.Validation.FluentValidation
{
    public class SupplierValidator:AbstractValidator<SupplierDTORequest>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tedarikçi Adı Boş Olamaz!!");
            RuleFor(x => x.Name).Length(2, 99).WithMessage("Tedarikçi Adı En Az Karakter Olmalıdır!!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Tedarikçi Numarası Boş Olamaz!!");
            RuleFor(x => x.Phone).Length(10, 15).WithMessage("Tedarikçi Numarası 10 Haneli Olmalıdır!!");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Tedarikçinin Adresi Boş Olmamalıdır!!");
        }
    }
}
