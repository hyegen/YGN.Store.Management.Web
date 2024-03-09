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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            var result = _repositoryManager.Category.FindAll(trackChanges);
            if (result is null)
                throw new Exception("Category Not Found");
            return result;
        }
    }
}
