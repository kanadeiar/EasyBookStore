using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Common;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels;

namespace EasyBookStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;
        public CatalogController(IProductData productData)
        {
            _productData = productData;
        }
        public IActionResult Index(int? GenreId, int? AuthorId)
        {
            var filter = new ProductFilter
            {
                GenreId = GenreId,
                AuthorId = AuthorId,
            };

            var products = _productData.GetProducts(filter);

            var model = new CatalogWebModel
            {
                GenreId = GenreId,
                AuthorId = AuthorId,
                Products = products
                    .OrderBy(p => p.Order)
                    .Select(p => new ProductWebModel
                    {
                        Id = p.Id,
                        Genre = p.Genre.Name,
                        Author = p.Author?.Name ?? "<Неизвестный>",
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Message = p.Message,
                    })
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var product = _productData.GetProduct(id);

            if (product is null)
                return NotFound();

            var model = new ProductWebModel
            {
                Id = product.Id,
                Author = product.Author?.Name ?? "<Неизвестный>",
                Genre = product.Genre.Name,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Message = product.Message,
            };

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
    }
}
