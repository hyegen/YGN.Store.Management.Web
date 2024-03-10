using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.Services.Contracts;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories.Contracts;

namespace YGN.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateProduct(Product product)
        {
            _repositoryManager.Product.Create(product);
            _repositoryManager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if (product is not null)
            {
                _repositoryManager.Product.DeleteOneProduct(product);
                _repositoryManager.Save();
            }

        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _repositoryManager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
                throw new ArgumentException("Product Not Found");

            return product;
        }

        public void UpdateOneProduct(Product product)
        {
            var entity = _repositoryManager.Product.GetOneProduct(product.ProductId, true);
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;
            _repositoryManager.Save();
        }
    }
}
