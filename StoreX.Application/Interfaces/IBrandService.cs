using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Brand?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Brand> AddAsync(Brand brand, CancellationToken cancellationToken = default);
        Task<Brand?> UpdateAsync(Brand brand, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
