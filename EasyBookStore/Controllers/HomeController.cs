using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Common;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EasyBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductData _productData;
        private readonly IMapper<ProductWebModel> _mapper;

        public HomeController(IConfiguration configuration, IProductData productData, IMapper<ProductWebModel> mapper)
        {
            _configuration = configuration;
            _productData = productData;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = (await _productData.GetProductsAsync(new ProductFilter {Ids = new []{1, 2, 3}}))
                .Select(p => _mapper.Map(p));

            ViewBag.NewBooks = (await _productData.GetProductsAsync(new ProductFilter { Ids = new[] { 4, 5, 6 } }))
                .Select(p => _mapper.Map(p));

            ViewBag.RecommendedBooks = (await _productData.GetProductsAsync(new ProductFilter { Ids = new[] { 1, 2, 3, 4, 5, 6, 7, 8 } }))
                .Select(p => _mapper.Map(p));

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
