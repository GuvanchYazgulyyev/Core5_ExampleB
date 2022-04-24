using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactSendMessageValidator: AbstractValidator<Contact>
    {
        public ContactSendMessageValidator()
        {
            RuleFor(k => k.ContactUserName).NotEmpty().WithMessage("Ad Soyad Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.ContactUserName).MinimumLength(5).WithMessage("Ad Soyad Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.ContactUserName).MaximumLength(40).WithMessage("Ad Soyad Alanı Max 40 Karakter Olmalıdır!!!");

            RuleFor(k => k.ContactMail).NotEmpty().WithMessage("E Posta Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.ContactMail).MinimumLength(5).WithMessage("E Posta Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.ContactMail).MaximumLength(50).WithMessage("E Posta Alanı Max 50 Karakter Olmalıdır!!!");

            RuleFor(k => k.ContactSubject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.ContactSubject).MinimumLength(7).WithMessage("Konu Alanı Min 7 Karakter Olmalıdır!!!");
            RuleFor(k => k.ContactSubject).MaximumLength(90).WithMessage("Konu Alanı Max 90 Karakter Olmalıdır!!!");

             RuleFor(k => k.ContactMessage).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.ContactMessage).MinimumLength(20).WithMessage("Mesaj Alanı Min 20 Karakter Olmalıdır!!!");
            RuleFor(k => k.ContactMessage).MaximumLength(500).WithMessage("Mesaj Alanı Max 500 Karakter Olmalıdır!!!");



        }
    }
}
