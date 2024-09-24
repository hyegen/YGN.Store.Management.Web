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


    }
}
