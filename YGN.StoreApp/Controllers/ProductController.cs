using Microsoft.AspNetCore.Mvc;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.RequestParameters;
using YGN.StoreApp.Models;
using YGN.StoreApp.Test;
using X.PagedList;
using YGN.StoreApp.Entities.Dtos;

namespace YGN.StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager repositoryManager)
        {
            _serviceManager = repositoryManager;
        }
        public IActionResult Index(ProductRequestParameters p, int page = 1, int pageSize = 6)
        {
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(p).ToPagedList(page, pageSize);

            ViewBag.MinPrice = p.MinPrice;
            ViewBag.MaxPrice = p.MaxPrice;
            ViewBag.SearchTerm = p.SearchTerm;

            return View(products);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _serviceManager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

    }
}
