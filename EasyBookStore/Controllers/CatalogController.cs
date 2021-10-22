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
            var authors = _productData.GetAuthors();
            var genres = _productData.GetGenres();

            var model = new CatalogWebModel
            {
                GenreId = GenreId,
                AuthorId = AuthorId,
                Products = products
                    .OrderBy(p => p.Order)
                    .Select(p => new ProductWebModel
                    {
                        Id = p.Id,
                        Author = authors.SingleOrDefault(a => a.Id == p.AuthorId)?.Name ?? "<Неизвестный>",
                        Genre = genres.SingleOrDefault(g => g.Id == p.GenreId)?.Name ?? "<Неизвестный>",
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Message = p.Message,
                    })
            };

            return View(model);
        }
    }
}
