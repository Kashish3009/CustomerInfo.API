using Microsoft.EntityFrameworkCore;
using CustomerInfo.API.Models;
using CustomerInfo.API.Data;
using CustomerOrders.API.Repositories.Interfaces;

namespace CustomerOrders.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerInformationContext dbContext;
        public CustomerRepository(CustomerInformationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            await dbContext.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            var existingcustomer = dbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (existingcustomer == null)
            {
                return null;
            }
            dbContext.Remove(existingcustomer);
            await dbContext.SaveChangesAsync();
            return existingcustomer;
        }

        public async Task<List<Customer>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                                      string? sortBy = null, bool isAscending = true,
                                                      int pageNumber = 1, int pageSize = 1000)
        {
                var customers = dbContext.Customers.AsQueryable();

                //Filtering
                if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
                {
                        if (filterOn.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                        {
                            customers = customers.Where(x => x.FirstName.Contains(filterQuery));
                        }
                        else if (filterOn.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                        {
                                customers = customers.Where(x => x.LastName.Contains(filterQuery));
                        }
                        else if (filterOn.Equals("Email", StringComparison.OrdinalIgnoreCase))
                        {
                            customers = customers.Where(x => x.Email.Contains(filterQuery));
                        }
                }

                // Sorting
                if (string.IsNullOrWhiteSpace(sortBy) == false)
                {

                    if (sortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                    {
                        customers = isAscending ? customers.OrderBy(x => x.FirstName) : customers.OrderByDescending(x => x.FirstName);
                    }
                    else if (sortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                    {
                        customers = isAscending ? customers.OrderBy(x => x.LastName) : customers.OrderByDescending(x => x.LastName);
                    }
                    else if (sortBy.Equals("Email", StringComparison.OrdinalIgnoreCase))
                    {
                    customers = isAscending ? customers.OrderBy(x => x.Email) : customers.OrderByDescending(x => x.Email);
                    }
                }

                //Pagination
                var skipResults = (pageNumber - 1) * pageSize;

            return await customers.Skip(skipResults).Take(pageSize).ToListAsync();

        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task<Customer?> UpdateAsync(int id, Customer customer)
        {
            var existingcustomer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (existingcustomer == null)
            {
                return null;
            }

            existingcustomer.FirstName = customer.FirstName;
            existingcustomer.LastName = customer.LastName;
            existingcustomer.Email = customer.Email;
            existingcustomer.PhoneNumber = customer.PhoneNumber;

            await dbContext.SaveChangesAsync();
            return existingcustomer;
        }
    }
}
