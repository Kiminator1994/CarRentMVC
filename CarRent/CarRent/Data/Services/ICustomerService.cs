using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetByIdAsync(int id);
        void Add(Customer customer);
        Task<Customer> UpdateAsync(int id, Customer customer);
        void Delete(int id);
    }
}
