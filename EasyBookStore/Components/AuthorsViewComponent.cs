using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyBookStore.Components
{
    public class AuthorsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;
        public AuthorsViewComponent(IProductData productData)
        {
            _productData = productData;
        }
        public IViewComponentResult Invoke()
        {
            var authors = _productData.GetAuthors().OrderBy(a => a.Order).Select(a => new AuthorWebModel
            {
                Id = a.Id,
                Name = a.Name,
                Order = a.Order,
            });

            return View(authors);
        }
    }
}
