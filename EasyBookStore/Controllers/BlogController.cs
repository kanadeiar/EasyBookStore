using Microsoft.AspNetCore.Mvc;

namespace EasyBookStore.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
