using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            var aboutvalues = aboutManager.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About p)
        {
            aboutManager.AboutAdd(p);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var aboutvalue = aboutManager.GetById(id);
            return View(aboutvalue);
        }
        [HttpPost]
        public IActionResult EditAbout(About p)
        {
            aboutManager.AboutUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
