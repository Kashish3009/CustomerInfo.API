using CustomerInfo.API.Models;

namespace CustomerOrders.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                         string? sortBy = null, bool isAscending = true,
                                         int pageNumber = 1, int pageSize = 1000);
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, Customer customer);
        Task<Customer?> DeleteAsync(int id);
    }
}
