using EntityLayer.Concrete;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");  
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklması boş geçilemez");  
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı 3 karakterden az olamaz");  
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı 50 karakterden fazla olamaz");
            RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("Kategori Açıklaması 3 karakterden az olamaz");


        }
    }
}
