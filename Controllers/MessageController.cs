using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace MvcProjeKampii.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageMaanger = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();   

        public IActionResult Inbox(string p)
        {
            var messagevalue = messageMaanger.GetListInbox(p);
            return View(messagevalue);
        }

        public IActionResult Sendbox(string p)
        {
            var messagevalue = messageMaanger.GetListSendbox(p);
            return View(messagevalue);
        }

        public IActionResult GetInboxMessageDetails(int id)
        {
            var messagetvalues = messageMaanger.GetByID(id);
            return View(messagetvalues);
        }

        public IActionResult GetSendboxMessageDetails(int id)
        {
            var messagetvalues = messageMaanger.GetByID(id);
            return View(messagetvalues);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = System.DateTime.Parse(System.DateTime.Now.ToShortDateString());
                messageMaanger.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
