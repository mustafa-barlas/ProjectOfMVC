using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public IActionResult Index()
        {
            var values = adminManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin p)
        {
            adminManager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var adminvalues = adminManager.GetByID(id);
            return View(adminvalues);
        }
        [HttpPost]
        public IActionResult EditAdmin(Admin p)
        {
            adminManager.AdminUpdate(p);    
            return RedirectToAction("Index");
        }
    }
}
