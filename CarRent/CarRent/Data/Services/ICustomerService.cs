using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        Customer Update(int id, Customer customer);
        bool Delete(int id);
    }
}
