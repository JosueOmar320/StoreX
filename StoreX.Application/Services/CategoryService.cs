using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;
using StoreX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> AddAsync(Category category, CancellationToken cancellationToken = default)
            => _categoryRepository.AddAsync(category, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _categoryRepository.DeleteAsync(id, cancellationToken);

        public Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
            => _categoryRepository.GetAllAsync(cancellationToken);

        public Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _categoryRepository.GetByIdAsync(id, cancellationToken);

        public Task<Category?> UpdateAsync(Category category, CancellationToken cancellationToken = default)
            => _categoryRepository.UpdateAsync(category, cancellationToken);
    }
}
