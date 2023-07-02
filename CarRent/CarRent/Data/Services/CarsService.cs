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
        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            var result = await _context.Cars.ToListAsync();
            return result;
        }

        public async  Task<Car> GetByIdAsync(int id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public Car Update(int id, Car car)
        {
            throw new NotImplementedException();
        }
    }
}
