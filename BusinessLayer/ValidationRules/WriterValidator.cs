using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(k => k.WriterName).NotEmpty().WithMessage("Ad Soyad Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.WriterName).MinimumLength(5).WithMessage("Ad Soyad Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.WriterName).MaximumLength(40).WithMessage("Ad Soyad Alanı Max 40 Karakter Olmalıdır!!!");

            RuleFor(k => k.WriterMail).NotEmpty().WithMessage("E Posta Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.WriterMail).MinimumLength(5).WithMessage("E Posta Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.WriterMail).MaximumLength(50).WithMessage("E Posta Alanı Max 50 Karakter Olmalıdır!!!");

          

           
            RuleFor(k => k.WriterPassword).NotEmpty().WithMessage("Şifre Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.WriterPassword).MinimumLength(6).WithMessage("Şifre Alanı Min 6 Karakter Olmalıdır!!!");
            RuleFor(k => k.WriterPassword).MaximumLength(16).WithMessage("Şifre Alanı Max 16 Karakter Olmalıdır!!!");

        }
    }
}
