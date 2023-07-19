using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        Task<Reservation> GetByIdAsync(int id);
        Task AddAsync(Reservation reservation);
        Task<Reservation> UpdateAsync(int id, Reservation reservation);
        void Delete(int id);
        Task<List<Reservation>> GetByCarIdAsync(int carId);
        int MaxNr();
    }
}
