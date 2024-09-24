using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.Services.Contracts;
using YGN.StoreApp.Entities.Dtos;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Entities.RequestParameters;
using YGN.StoreApp.Repositories.Contracts;

namespace YGN.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
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

        public IEnumerable<ProductGetAllDto> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            var products = _repositoryManager.Product.GetAllProductsWithDetails(p);
            // var allProductsDto=_mapper.Map<ProductGetAllDto>(products);

            var allProductsDto = _mapper.Map<IEnumerable<ProductGetAllDto>>(products);

            return allProductsDto;
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _repositoryManager
                .Product
                .FindAll(trackChanges)
                .OrderByDescending(x => x.ProductId)
                .Take(n);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
                throw new ArgumentException("Product Not Found");

            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);

            return productDto;
        }

        public IEnumerable<ProductGetAllDto> GetShowcaseProducts(bool trackChanges)
        {
            var products = _repositoryManager.Product.GetShowcaseProducts(trackChanges);
            //var products = GetShowcaseProducts(trackChanges);         //TODO => TRY IT

            var allProductDto = _mapper.Map<IEnumerable<ProductGetAllDto>>(products);
            return allProductDto;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //var entity = _repositoryManager.Product.GetOneProduct(productDto.ProductId, true);
            //entity.ProductName = productDto.ProductName;
            //entity.Price = productDto.Price;
            //entity.CategoryId= productDto.CategoryId;   

            var entity = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.UpdateOneProduct(entity);
            _repositoryManager.Save();
        }


    }
}
