﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Common;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services;
using EasyBookStore.WebModels;

namespace EasyBookStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;
        private readonly IMapper<ProductWebModel> _mapper;
        public CatalogController(IProductData productData, IMapper<ProductWebModel> mapper)
        {
            _productData = productData;
            _mapper = mapper;
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
                    .Select(p => _mapper.Map(p))
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var product = _productData.GetProduct(id);

            if (product is null)
                return NotFound();

            var model = _mapper.Map(product);

            ViewBag.RecommendedBooks = _productData.GetProducts(new ProductFilter { Ids = new[] { 1, 2, 3, 4, 5, 6, 7, 8 } })
                .Select(p => _mapper.Map(p));

            return View(model);
        }
    }
}
