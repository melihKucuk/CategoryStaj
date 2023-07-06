using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryStaj.Business.ViewModels
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Ürün fiyatı boş olamaz.")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            RuleFor(product => product.CategoryId)
                .NotEmpty().WithMessage("Kategori ID boş olamaz.")
                .GreaterThan(0).WithMessage("Kategori ID 0'dan büyük olmalıdır.");

            RuleFor(product => product).Custom((product, context) =>
            {
                if (product == null)
                {
                    return;
                }

                if (product.Category != null)
                {
                    context.AddFailure("Geçersiz alan: Category");
                }
            });
        }

        public bool IsValidModel(ProductViewModel model)
        {
            var validator = new ProductViewModelValidator();
            var context = new ValidationContext<ProductViewModel>(model);
            var result = validator.Validate(context);
            return result.IsValid;
        }
    }
}
