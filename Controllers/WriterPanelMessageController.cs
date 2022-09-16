using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageMaanger = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        

        public PartialViewResult MyMessageMenu()
        {
            return PartialView();
        }

        public IActionResult MyInbox(string p) // burdaki p silinecek
        {
            //string p = (string)Session["WriterMail"];

            var messagevalue = messageMaanger.GetListInbox(p); // session daki p burda kulanılacak
            return View(messagevalue);
        }
       
        public IActionResult MySendbox(string p) // burdaki p silinecek
        {
            //string p = (string)Session["WriterMail"];

            var messagevalue = messageMaanger.GetListSendbox(p);     // session daki p burda kulanılacak
            return View(messagevalue);
        }

        public IActionResult GetMyInboxMessageDetails(int id)
        {
            var messagetvalues = messageMaanger.GetByID(id);
            return View(messagetvalues);
        }

        public IActionResult GetMySendboxMessageDetails(int id)
        {
            var messagetvalues = messageMaanger.GetByID(id);
            return View(messagetvalues);
        }

        [HttpGet]
        public IActionResult NewMyMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMyMessage(Message p)
        {
            //string sender = (string)Session["WriterMail"];

            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageSenderMail = "admin@gmail.com"; //sender
                p.MessageDate = System.DateTime.Parse(System.DateTime.Now.ToShortDateString());
                messageMaanger.MessageAdd(p);
                return RedirectToAction("MySendbox");
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
