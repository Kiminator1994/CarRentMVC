using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data.Services
{
    public class RentalContractsService : IRentalContractsService
    {
        private readonly AppDbContext _context;
        public RentalContractsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RentalContract rentalContract)
        {
            await _context.RentalContracts.AddAsync(rentalContract);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var rentalContract = _context.RentalContracts.Find(id);
            _context.RentalContracts.Remove(rentalContract);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<RentalContract>> GetAllAsync()
        {
            return await _context.RentalContracts.ToListAsync();
        }

        public async Task<RentalContract> GetAsync(RentalContract rentalContract)
        {
            return await _context.RentalContracts.FirstOrDefaultAsync(r => r.Nr == rentalContract.Nr);
        }

        public async Task<RentalContract> GetByIdAsync(int id)
        {
            return await _context.RentalContracts.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RentalContract> GetContractByReservationId(int resId)
        {
            return await _context.RentalContracts.FirstOrDefaultAsync(ren => ren.ReservationId == resId);
        }


        public int MaxNr()
        {
            try
            {
                var number = (from r in _context.RentalContracts
                              select r.Nr).Max();
                return number;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<RentalContract> UpdateAsync(int id, RentalContract newRentalContract)
        {
            _context.RentalContracts.Update(newRentalContract);
            await _context.SaveChangesAsync();
            return newRentalContract;
        }
    }
}
