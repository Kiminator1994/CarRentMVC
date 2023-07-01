using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            var result = await _context.Reservations.ToListAsync();
            return result;
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Reservation Update(int id, Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
