using Microsoft.AspNetCore.Mvc;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories.Contracts;

namespace YGN.StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var result = _serviceManager.CategoryService.GetAllCategories(false);
            return View(result);
        }
    }
}
