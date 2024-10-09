using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YGN.Services.Contracts.Manager;

namespace YGN.StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TestApiController(IServiceManager repositoryManager)
        {
            _serviceManager = repositoryManager;
        }

        [HttpGet]
        public string GetProducts()
        {
            var result = _serviceManager.ProductService.GetAllProducts(false);

            var json = JsonConvert.SerializeObject(result);
            return json;
        }
    }
}
