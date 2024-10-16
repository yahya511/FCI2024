using Domain.Models;

namespace Infrastructure.IRepositories
{
    public interface IAddressRepository
    {
        Task<Town> AddAsync(Town town);
        Task<Town?> GetByIdAsync(Guid id);
        Task<List<Town>> GetAllAsync();
        Task UpdateAsync(Town town);
        Task DeleteAsync(Guid id);
    }
}
