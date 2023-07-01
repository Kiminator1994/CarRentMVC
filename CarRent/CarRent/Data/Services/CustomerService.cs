using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
