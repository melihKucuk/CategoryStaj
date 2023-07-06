using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace CategoryStaj.Business.ViewModels.Validations
{
    public class CategoryViewModelValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryViewModelValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır.");
        }
    }

}

