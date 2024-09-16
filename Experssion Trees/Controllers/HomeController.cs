using Experssion_Trees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
 

namespace Experssion_Trees.Controllers
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

        
    }
}
