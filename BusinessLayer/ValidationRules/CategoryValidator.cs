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

            RuleFor(k => k.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılmaz!!!");
            RuleFor(k => k.CategoryName).MinimumLength(5).WithMessage("Kategori Adı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.CategoryName).MaximumLength(100).WithMessage("Kategori Adı Max 100 Karakter Olmalıdır!!!");


            RuleFor(k => k.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklama Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.CategoryDescription).MinimumLength(20).WithMessage("Kategori Açıklama Min 20 Karakter Olmalıdır!!!");
            RuleFor(k => k.CategoryDescription).MaximumLength(200).WithMessage("Kategori Açıklama Max 200 Karakter Olmalıdır!!!");

        }
    }
}
