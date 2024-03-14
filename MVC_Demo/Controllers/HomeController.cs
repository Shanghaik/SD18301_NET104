using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models;
using System.Diagnostics;

namespace MVC_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Brivacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View(); // Trỏ đến view cùng tên với action
            //return NoContent();
            //return BadRequest();
        }
        public IActionResult GoToHome() { 
            // Hành động gì đó trước khi về trang chủ
            // Redirect - điều hướng về action để về trang chủ
            return RedirectToAction("Index");
            // return RedirectToPage("Index.cshtml");
            // return RedirectToRoute("/Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}