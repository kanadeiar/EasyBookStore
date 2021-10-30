using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace EasyBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Administrators)]
    public class ProductController : Controller
    {
        private readonly IProductData _productData;
        private readonly IMapper<ProductWebModel> _mapper;

        public ProductController(IProductData productData, IMapper<ProductWebModel> mapper)
        {
            _productData = productData;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productData.GetProductsAsync();
            return View(products.Select(p => _mapper.Map(p)));
        }
    }
}
