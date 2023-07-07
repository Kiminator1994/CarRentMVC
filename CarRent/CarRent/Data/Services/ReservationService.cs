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

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();

            
        }


        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r =>  r.Id == id);
        }

        public async Task<List<Reservation>> GetByCarIdAsync(int carId)
        {
             return await _context.Reservations.Where(res => res.CarId == carId).ToListAsync();
        }

        public async Task<Reservation> UpdateAsync(int id, Reservation newReservation)
        {
            _context.Update(newReservation);
            await _context.SaveChangesAsync();
            return newReservation;
        }
    }
}
