using FluentValidation;

namespace CategoryStaj.Business.ViewModels
{
    public class ProductCreateViewModelValidator : AbstractValidator<ProductCreateViewModel>
    {
        public ProductCreateViewModelValidator()
        {
            RuleFor(product => product)
                .NotNull().WithMessage("Ürün bilgileri boş olamaz.");

            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Ürün fiyatı boş olamaz.")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            RuleFor(product => product.CategoryId)
                .NotEmpty().WithMessage("Kategori ID boş olamaz.")
                .GreaterThan(0).WithMessage("Kategori ID 0'dan büyük olmalıdır.");
        }
    }
}
