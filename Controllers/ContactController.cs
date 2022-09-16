using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public IActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public IActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id); 
            return View(contactvalues);  
        }
        public PartialViewResult MessageMenu()
        {
            return PartialView();
        }
    }
}
