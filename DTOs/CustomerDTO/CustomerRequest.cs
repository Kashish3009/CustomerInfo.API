using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.API.DTOs.CustomerDTO
{
    public class CustomerRequest
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
