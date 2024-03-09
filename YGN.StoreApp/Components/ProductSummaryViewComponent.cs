using Microsoft.AspNetCore.Mvc;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Repositories;

namespace YGN.StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public ProductSummaryViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public string Invoke()
        {
            return _serviceManager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
