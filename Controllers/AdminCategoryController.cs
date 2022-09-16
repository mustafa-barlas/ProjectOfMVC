using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager( new EfCategoryDal());

       // [Authorize(Roles="B")]

        public IActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [   HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();  
            ValidationResult results = categoryValidator.Validate(p);   
            if (results.IsValid)
            {
                cm.CategoryAdd(p);  
                return RedirectToAction("Index");   
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
        public IActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id); 
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public IActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
