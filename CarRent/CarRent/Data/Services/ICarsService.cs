using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetAll();
        Car GetById(int id);
        void Add(Car car);
        Car Update(int id, Car car);
        bool Delete(int id);
    }
}
