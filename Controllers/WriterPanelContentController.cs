using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public IActionResult MyContent(string p)
        {
           
            //  p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();  
            // ViewBag.d = p;
            var contentValue = contentManager.GetListByWriter(writerIdInfo);    
            return View(contentValue);
        }
        [HttpGet]
        public IActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();  
        }
        [HttpPost]
        public IActionResult AddContent(Content p)
        {
            // string mail = (string)Session["WriterMail"];
            //var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 1;// writerIdInfo
            p.ContentStatus = true;
            contentManager.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}
