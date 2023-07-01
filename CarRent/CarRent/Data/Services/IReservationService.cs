using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAll();
        Reservation GetById(int id);
        void Add(Reservation reservation);
        Reservation Update(int id, Reservation reservation);
        bool Delete(int id);
    }
}
