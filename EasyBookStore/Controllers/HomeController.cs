using System.Linq;
using EasyBookStore.Domain.Common;
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
            var model = _productData.GetProducts(new ProductFilter {Ids = new []{1, 2, 3}})
                .Select(p => new ProductWebModel
                {
                    Id = p.Id,
                    Genre = p.Genre.Name,
                    Author = p.Author?.Name ?? "<Неизвестный>",                
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Message = p.Message,
                });

            ViewBag.NewBooks = _productData.GetProducts(new ProductFilter { Ids = new[] { 4, 5, 6 } })
                .Select(p => new ProductWebModel
                {
                    Id = p.Id,
                    Genre = p.Genre.Name,
                    Author = p.Author?.Name ?? "<Неизвестный>",
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Message = p.Message,
                });

            ViewBag.RecommendedBooks = _productData.GetProducts(new ProductFilter { Ids = new[] { 1, 2, 3, 4, 5, 6, 7, 8 } })
                .Select(p => new ProductWebModel
                {
                    Id = p.Id,
                    Genre = p.Genre.Name,
                    Author = p.Author?.Name ?? "<Неизвестный>",
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
