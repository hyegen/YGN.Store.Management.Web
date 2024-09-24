using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YGN.StoreApp.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using YGN.StoreApp.Entities.Models;

namespace YGN.StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public class TestProduct
        {
            public string ProductCode { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string ItemType { get; set; }
            public string Price { get; set; }
        }

    }
}
