using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.StoreApp.Entities.Models;

namespace YGN.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id,bool trackChanges);
        void CreateProduct(Product product);
        void UpdateOneProduct(Product product);
        void DeleteOneProduct(int id);
    }
}
