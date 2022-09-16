using Microsoft.AspNetCore.Mvc;
using MvcProjeKampii.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace MvcProjeKampii.Controllers
{
    public class ChartController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> charts = new List<CategoryChart>();
            charts.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount = 10,
            });
            charts.Add(new CategoryChart()
            {
                CategoryName = "Tiyatro",
                CategoryCount = 5,
            });

            return charts;  
        }
    }
}
