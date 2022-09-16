using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Page403()
        {
            Response.StatusCode = 403;
          //  Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public IActionResult Page404()
        {
            Response.StatusCode = 404;
            //  Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}
