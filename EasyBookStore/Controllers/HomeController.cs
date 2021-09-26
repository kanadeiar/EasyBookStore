using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EasyBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
