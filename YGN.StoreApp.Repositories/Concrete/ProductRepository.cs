using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Entities.RequestParameters;
using YGN.StoreApp.Repositories.Contracts;
using YGN.StoreApp.Repositories.Extensions;

namespace YGN.StoreApp.Repositories.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }
        public void CreateOneProduct(Product product) => Create(product);
        public void DeleteOneProduct(Product product) => Remove(product);
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters param)
        {
            var a = _context
                .Products
                .FilteredByCategoryId(param.CategoryId)
                .FilteredBySearchTerm(param.SearchTerm)
                .FilteredByPrice(param.MinPrice,param.MaxPrice,param.isValidPrice);
            return a;
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }
        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(x => x.ShowCase.Equals(true));
        }
        public void UpdateOneProduct(Product entity) => Update(entity);
    }
}
