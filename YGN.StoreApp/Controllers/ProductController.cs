using Microsoft.AspNetCore.Mvc;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.RequestParameters;
using YGN.StoreApp.Models;

namespace YGN.StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager repositoryManager)
        {
            _serviceManager = repositoryManager;
        }
        public IActionResult Index(ProductRequestParameters p)
        {
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _serviceManager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel()
            {
                Pagination = pagination,
                Products = products
            });
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _serviceManager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

    }
}
