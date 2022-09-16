using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ımageFileManager = new ImageFileManager(new EfImageFileDal());
        public IActionResult Index()
        {
            var ımageFileValue = ımageFileManager.GetList();
            return View(ımageFileValue);
        }
        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGallery(ImageFile p)
        {
            ımageFileManager.ImageFileAdd(p);
            return RedirectToAction("Index");
        }
    }
}
