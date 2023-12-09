using AutoMapper;
using CustomerInfo.API.DTOs.CustomerDTO;
using CustomerInfo.API.Models;
using CustomerOrders.API.DTOs.CustomerDTO;

namespace MusicPlayer.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
            public AutoMapperProfiles()
            {
                CreateMap<Customer, CustomerRequest>().ReverseMap();
                CreateMap<Customer, CustomerResponse>().ReverseMap();
                CreateMap<Customer, UpdateCustomer>().ReverseMap();
            }

    }
}
