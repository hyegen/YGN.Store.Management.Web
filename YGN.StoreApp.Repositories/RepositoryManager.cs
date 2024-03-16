using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.StoreApp.Repositories.Contracts;

namespace YGN.StoreApp.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        public RepositoryManager(IProductRepository productRepository, RepositoryContext repositoryContext, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _context = repositoryContext;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository Product => _productRepository;
        public ICategoryRepository Category => _categoryRepository;
        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
