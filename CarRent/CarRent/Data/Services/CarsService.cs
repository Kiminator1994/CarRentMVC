using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data.Services
{
    public class CarsService : ICarsService
    {
        private readonly AppDbContext _context;


        public CarsService(AppDbContext context)
        {
            _context = context;
        }
        public async void AddAsync(Car car)
        {
            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                
            }
            
        }

        public void Delete(int id)
        {

            
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            var result = await _context.Cars.ToListAsync();
            return result;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public Car Update(int id, Car car)
        {
            throw new NotImplementedException();
        }
        public int MaxNr()
        {
            var number = (from car in _context.Cars
                          select car.Nr).Max();
            return number;
        }
    }
}
