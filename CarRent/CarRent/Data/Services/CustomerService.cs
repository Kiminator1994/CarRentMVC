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
        public  void Add(Customer customer)
        {
            _context.Customers.Add(customer);           
            _context.SaveChangesAsync();           
        }

        public async Task<Customer> Get(Customer customer)
        {
            return await _context.Customers.Where(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName && c.Address == customer.Address && c.City == customer.City).FirstOrDefaultAsync();
        }
        public void Delete(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Customer> UpdateAsync(int id, Customer newCustomer)
        {
            _context.Update(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer;
        }
    }
}
