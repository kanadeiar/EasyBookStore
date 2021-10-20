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
            var authors = _productData.GetAuthors();
            var genres = _productData.GetGenres();

            var model = products.Take(3).Select(p => new ProductWebModel
            {
                Id = p.Id,
                Author = authors.SingleOrDefault(a => a.Id == p.AuthorId)?.Name ?? "<Неизвестный>",
                Genre = genres.SingleOrDefault(g => g.Id == p.GenreId)?.Name ?? "<Неизвестный>",
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Message = p.Message,
            });

            ViewBag.NewBooks = products.Skip(3).Take(3).Select(p => new ProductWebModel
            {
                Id = p.Id,
                Author = authors.SingleOrDefault(a => a.Id == p.AuthorId)?.Name ?? "<Неизвестный>",
                Genre = genres.SingleOrDefault(g => g.Id == p.GenreId)?.Name ?? "<Неизвестный>",
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Message = p.Message,
            });

            ViewBag.RecommendedBooks = products.Take(8).Select(p => new ProductWebModel
            {
                Id = p.Id,
                Author = authors.SingleOrDefault(a => a.Id == p.AuthorId)?.Name ?? "<Неизвестный>",
                Genre = genres.SingleOrDefault(g => g.Id == p.GenreId)?.Name ?? "<Неизвестный>",
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
    }
}
