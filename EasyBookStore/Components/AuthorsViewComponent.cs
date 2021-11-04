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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authors = (await _productData.GetAuthorsAsync())
                .OrderBy(a => a.Order).Select(a => new AuthorWebModel
            {
                Id = a.Id,
                Name = a.Name,
                Order = a.Order,
                CountProducts = a.Products.Count,
            });

            return View(authors);
        }
    }
}
