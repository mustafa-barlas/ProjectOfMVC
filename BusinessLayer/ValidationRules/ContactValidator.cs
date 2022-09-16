using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator :AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Lütfen Mail Alanını Doldurunuz"); // mail empty
           
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Kategori adı boş geçilemez"); // subject empty
            RuleFor(x => x.Subject).MinimumLength(50).WithMessage("Konu Alanı 3 karakterden az olamaz"); //subject min 3

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kategori açıklması boş geçilemez"); //UserName empty
            RuleFor(x => x.UserName).MaximumLength(25).WithMessage("Kulanıcı Adı 25 karakterden fazla olamaz"); //UserName max 25
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kulanıcı Adı 3 karakterden fazla olamaz"); //UserName min 3
        }
    }
}
