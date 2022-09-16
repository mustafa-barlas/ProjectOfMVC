using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez"); //ad

            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı 2 karakterden az olamaz"); //ad

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemezz"); //soyadı

            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar Soyadı 2 karakterden az olamaz"); //soyadı

            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı Boş Geçilemez"); //unvan

            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Yazar Unvanı 2 karakterden az olamaz"); //unvan

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("mail addresi boş geçilemez"); //mail

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş geçilemez"); //şifre

            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("Şifre En Az 8 karakterden oluşmalı"); //şifre
        } 
    }
}
