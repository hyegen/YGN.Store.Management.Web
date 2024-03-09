using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.Services.Contracts;
using YGN.Services.Contracts.Manager;

namespace YGN.Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ServiceManager(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public ICategoryService CategoryService => _categoryService;
        public IProductService ProductService => _productService;
    }
}
