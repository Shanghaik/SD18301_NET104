using Microsoft.AspNetCore.Mvc;

namespace MVC_Demo.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
