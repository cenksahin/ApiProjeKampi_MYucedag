using ApiProjeKampi.WebApi.Entities;
using FluentValidation;


namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adını gir");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("En az 2 karakter");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyatı gir")
                .GreaterThan(0).WithMessage("0'dan büyük olmalı")
                .LessThan(1000).WithMessage("1000'den küçük olmalı");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Açıklama gir");
        }
    }
}