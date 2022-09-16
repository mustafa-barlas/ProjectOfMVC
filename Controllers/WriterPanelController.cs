using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();
        WriterValidator writerValidator = new WriterValidator();
        Context context = new Context();

        [HttpGet]
        public IActionResult WriterProfile(int id)
        {
            // p = (string)Session["WriterMail"];
             var p ="";
            id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = writerManager.GetByID(id);
            return View(writerValue);
        }
        [HttpGet]
        public IActionResult EditWriter(int id)
        {
            var writerValues = writerManager.GetByID(id);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public IActionResult MyHeading(string p)
        {
            
           // p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerIdInfo);
            return View(values);
        }
        [HttpGet]
        public IActionResult NewMyHeading()
        {
            
           
            List<SelectListItem> valueCategoryy = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.vlcc = valueCategoryy;
            return View();
        }
        [HttpPost]
        public IActionResult NewMyHeading(Heading p)
        {

            // string value = (string)Session["WriterMail"];
            // var writerIdInfo = context.Writers.Where(x => x.WriterMail == value).Select(y => y.WriterID).FirstOrDefault();
           // ViewBag.d = writerIdInfo;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 1; // writerIdInfo
            headingManager.HeadingAdd(p);
            return RedirectToAction("MyHeading");
            
        }
        [HttpGet]
        public IActionResult EditMyHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingvalue = headingManager.GetByID(id);
            return View(headingvalue);
        }
        [HttpPost]
        public IActionResult EditMyHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public IActionResult DeleteMyHeading(int id)
        {
            var Myheadingvalue = headingManager.GetByID(id);
            Myheadingvalue.HeadingStatus = false;
            headingManager.HeadingUpdate(Myheadingvalue);
            return RedirectToAction("MyHeading");
        }
        public IActionResult AllHeading(int p = 1)
        {
            var allHeading = headingManager.GetList().ToPagedList(p, 10);
            return View(allHeading);
        }
    }
}
