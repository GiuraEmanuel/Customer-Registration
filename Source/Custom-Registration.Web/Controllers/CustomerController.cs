using Microsoft.AspNetCore.Mvc;

namespace Custom_Registration.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
