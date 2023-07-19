using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CarRent.Data.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
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
            _context.Reservations.Update(newReservation);
            await _context.SaveChangesAsync();
            return newReservation;
        }

        public int MaxNr()
        {
            try
            {
                var number = (from r in _context.Reservations
                              select r.Nr).Max();
                return number;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
