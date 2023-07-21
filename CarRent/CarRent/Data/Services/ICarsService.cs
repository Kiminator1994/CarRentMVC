using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> GetByIdAsync(int id);
        Task AddAsync(Car car);
        Car Update(int id, Car car);
        void Delete(int id);
        int MaxNr();
    }
}
