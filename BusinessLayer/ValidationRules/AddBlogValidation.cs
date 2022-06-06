using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddBlogValidation : AbstractValidator<Blog>
    {
        public AddBlogValidation()
        {
            RuleFor(k => k.BlogTitle).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.BlogTitle).MinimumLength(5).WithMessage("Başlık Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.BlogTitle).MaximumLength(100).WithMessage("Başlık Alanı Max 100 Karakter Olmalıdır!!!");


            RuleFor(k => k.BlogContent).NotEmpty().WithMessage("Blog İçerik Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.BlogContent).MinimumLength(200).WithMessage("Blog İçerik Alanı Min 200 Karakter Olmalıdır!!!");
            RuleFor(k => k.BlogContent).MaximumLength(9000).WithMessage("Blog İçerik Alanı Max 9000 Karakter Olmalıdır!!!");

           // RuleFor(k => k.BlogImage).NotEmpty().WithMessage("Resim  Alanı Boş Bırakılmaz!!!");

        }
    }
}
