using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddCommentValidator: AbstractValidator<Comment>
    {
        public AddCommentValidator()
        {
            RuleFor(k => k.CommentUserName).NotEmpty().WithMessage("Ad Soyad Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.CommentUserName).MinimumLength(5).WithMessage("Ad Soyad Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.CommentUserName).MaximumLength(40).WithMessage("Ad Soyad Alanı Max 40 Karakter Olmalıdır!!!");

           
            RuleFor(k => k.CommentTitle).NotEmpty().WithMessage("Yorum Başlık Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.CommentTitle).MinimumLength(5).WithMessage("Yorum Başlık Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.CommentTitle).MaximumLength(90).WithMessage("Yorum Başlık Alanı Max 90 Karakter Olmalıdır!!!");

            RuleFor(k => k.CommentContent).NotEmpty().WithMessage("Yorum  Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.CommentContent).MinimumLength(20).WithMessage("Yorum  Alanı Min 20 Karakter Olmalıdır!!!");
            RuleFor(k => k.CommentContent).MaximumLength(500).WithMessage("Yorum  Alanı Max 500 Karakter Olmalıdır!!!");

           

        }
    }
}
