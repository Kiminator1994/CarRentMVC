using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        Task<Reservation> GetByIdAsync(int id);
        void Add(Reservation reservation);
        Task<Reservation> UpdateAsync(int id, Reservation reservation);
        bool Delete(int id);
        Task<List<Reservation>> GetByCarIdAsync(int carId);
    }
}
