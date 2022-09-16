using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public IActionResult Headings()
        {
           
            var headingvalues = headingManager.GetList();
            
            return View(headingvalues);
        }
        public PartialViewResult Index(int id=1)
        {
            var contentList = contentManager.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}
