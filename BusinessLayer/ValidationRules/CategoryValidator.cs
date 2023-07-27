using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Category adını boş bırakamassınız");
            RuleFor(x => x.CategoryDescriptin).NotEmpty().WithMessage("Acıklamayi boş gecemessiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("lütfen enaz 3karakter girin");
        }


    }
}
