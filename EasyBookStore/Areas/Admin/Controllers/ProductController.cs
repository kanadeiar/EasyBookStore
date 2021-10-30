using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using EasyBookStore.Domain.Models;

namespace EasyBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Administrators)]
    public class ProductController : Controller
    {
        private readonly IProductData _productData;
        private readonly IMapper<ProductEditWebModel> _mapperToWeb;
        private readonly IMapper<Product> _mapperFromWeb;

        public ProductController(IProductData productData, IMapper<ProductEditWebModel> mapperToWeb, IMapper<Product> mapperFromWeb)
        {
            _productData = productData;
            _mapperToWeb = mapperToWeb;
            _mapperFromWeb = mapperFromWeb;
        }

        public async Task<IActionResult> Index()
        {
            var products = (await _productData.GetProductsAsync(includes:true)).OrderBy(p => p.Order);
            return View(products.Select(p => _mapperToWeb.Map(p)));
        }

        public async Task<IActionResult> Create()
        {
            return View("Edit", new ProductEditWebModel());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is not { } productId) return View(new ProductEditWebModel());

            var product = await _productData.GetProductAsync(productId);
            if (product is null) return NotFound();

            var model = _mapperToWeb.Map(product);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var product = await _productData.GetProductAsync(id);
            if (product is null) return NotFound();

            var model = _mapperToWeb.Map(product);
            return View(model);
        }
    }
}
