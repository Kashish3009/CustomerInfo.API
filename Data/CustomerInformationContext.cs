using System;
using System.Collections.Generic;
using CustomerInfo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.API.Data;

public partial class CustomerInformationContext : DbContext
{
    public CustomerInformationContext()
    {
    }
    public CustomerInformationContext(DbContextOptions<CustomerInformationContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Customer> Customers { get; set; }

}
