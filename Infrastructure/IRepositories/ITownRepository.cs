
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface ITownRepository : IGenericRepository<Town>
    {
        // يمكنك إضافة وظائف إضافية خاصة بـ Town هنا إذا لزم الأمر
    }
}




/* 
using Domain.Models;

namespace Infrastructure.IRepositories
{
    public interface ITownRepository
    {
        Task<Town> AddAsync(Town town);
        Task<Town?> GetByIdAsync(Guid id);
        Task<List<Town>> GetAllAsync();
        Task UpdateAsync(Town town);
        Task DeleteAsync(Guid id);
    }
} */


