using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MvcProjeKampii.Controllers
{
    public class ContentController : Controller
    {

        ContentManager contentManager = new ContentManager(new EfContentDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllContent(string r)
        {

            var values = contentManager.GetList(r);
           
            return View(values);
        }
        public IActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}
