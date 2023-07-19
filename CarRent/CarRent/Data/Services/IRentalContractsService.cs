using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface IRentalContractsService
    {
        Task<IEnumerable<RentalContract>> GetAllAsync();
        Task<RentalContract> GetByIdAsync(int id);
        Task AddAsync(RentalContract rentalContract);
        Task<RentalContract> GetAsync(RentalContract rentalContract);
        Task<RentalContract> UpdateAsync(int id, RentalContract rentalContract);
        void Delete(int id);
        int MaxNr();
    }
}
