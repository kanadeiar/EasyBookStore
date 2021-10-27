using System.Linq;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EasyBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductData _productData;
        public HomeController(IConfiguration configuration, IProductData productData)
        {
            _configuration = configuration;
            _productData = productData;
        }
        public IActionResult Index()
        {
            var products = _productData.GetProducts();
            var genresPool = _productData.GetGenres().ToDictionary(g => g.Id);
            var authorsPool = _productData.GetAuthors().ToDictionary(a => a.Id);

            var model = products.Take(3).Select(p => new ProductWebModel
            {
                Id = p.Id,
                Genre = genresPool[p.GenreId]?.Name ?? "<Неизвестный>",
                Author = authorsPool[p.AuthorId ?? 0]?.Name ?? "<Неизвестный>",                
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Message = p.Message,
            });

            ViewBag.NewBooks = products.Skip(3).Take(3).Select(p => new ProductWebModel
            {
                Id = p.Id,
                Genre = genresPool[p.GenreId]?.Name ?? "<Неизвестный>",
                Author = authorsPool[p.AuthorId ?? 0]?.Name ?? "<Неизвестный>",
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Message = p.Message,
            });

            ViewBag.RecommendedBooks = products.Take(8).Select(p => new ProductWebModel
            {
                Id = p.Id,
                Genre = genresPool[p.GenreId]?.Name ?? "<Неизвестный>",
                Author = authorsPool[p.AuthorId ?? 0]?.Name ?? "<Неизвестный>",
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Message = p.Message,
            });

            return View(model);
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Error(string id)
        {
            switch (id)
            {
                default: return Content($"Status --- {id}");
                case "404": return View("Error404");
            }
            
        }
    }
}
