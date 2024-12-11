using Microsoft.AspNetCore.Mvc;

namespace ZooShop.Controllers
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
            _logger.LogInformation("Index action of HomeController is called.");
            return View();  // Повертає представлення Index.cshtml
        }
    }
}
