using CarRent.Models;

namespace CarRent.Data.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task<Customer> GetAsync(Customer customer);
        Task<Customer> UpdateAsync(int id, Customer customer);
        void Delete(int id);
        int MaxNr();
    }
}
