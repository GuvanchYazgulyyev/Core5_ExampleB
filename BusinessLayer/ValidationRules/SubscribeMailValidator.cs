using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeMailValidator: AbstractValidator<SubscribeMail>
    {
        public SubscribeMailValidator()
        {
            RuleFor(k => k.Mail).NotEmpty().WithMessage("E Posta Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.Mail).MinimumLength(5).WithMessage("E Posta Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.Mail).MaximumLength(30).WithMessage("E Posta Alanı Max 50 Karakter Olmalıdır!!!");
        }
    }
}
