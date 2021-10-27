using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyBookStore.Components
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IProductData _productData;
        public GenresViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _productData.GetGenresWithProducts();
            var parents = genres.Where(g => g.ParentId is null);

            var parentsViews = parents.Select(p => new GenreWebModel
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                CountProducts = p.Products.Count,
            }).ToList();

            foreach (var parent in parentsViews)
            {
                var child = genres.Where(g => g.ParentId == parent.Id);
                foreach (var kind in child)
                    parent.Child.Add(new GenreWebModel
                    {
                        Id = kind.Id,
                        Name = kind.Name,
                        Order = kind.Order,
                        Parent = parent,
                        CountProducts = kind.Products.Count,
                    });
                parent.Child.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            }

            parentsViews.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));

            return View(parentsViews);
        }
    }
}
