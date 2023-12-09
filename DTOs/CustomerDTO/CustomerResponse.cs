//using CustomerInfo.API.Models;

namespace CustomerOrders.API.DTOs.CustomerDTO
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

    }
}
