using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//save

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> Logger)
        {
            _logger = Logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}