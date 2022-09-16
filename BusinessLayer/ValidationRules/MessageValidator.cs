using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator :AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageReceiverMail).NotEmpty().WithMessage("Gönderici maili boş geçilemez"); // Receiver not empty

            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu boş geçilemez"); // subject not empty

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("içerik boş geçilemez"); // content not empty

            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Konu en az 3 karakter olmalı"); // subject min 

            RuleFor(x => x.MessageSubject).MaximumLength(100).WithMessage("Konu en fazla 100 karakter olabilir"); // subject max

        }
    }
}
