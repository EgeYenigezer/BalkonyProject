using BalkonyEntity.DTO.Product;
using FluentValidation;



namespace BalkonyApi.Validation.FluentValidation
{
    public class ProductValidator:AbstractValidator<ProductDTORequest>
    {

        public ProductValidator()
        {
            RuleFor(x => x.Name).Length(2, 99).WithMessage("Ürün Adı En Az İki Karakter Olmalıdır!!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün Adı Boş Olamaz!!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı Boş Olamaz!!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün Açıklaması Boş Olamaz!!");
        }
    }
}
