using BalkonyEntity.DTO.Stock;
using FluentValidation;

namespace BalkonyApi.Validation.FluentValidation
{
    public class StockValidator:AbstractValidator<StockDTORequest>
    {
        public StockValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Stock İçin Ürün Eklenmelidir!!");
        }
    }
}
