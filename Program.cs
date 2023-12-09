using CustomerInfo.API.Data;
using CustomerOrders.API.Repositories;
using CustomerOrders.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MusicPlayer.API.Mappings;
using Serilog;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>options.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerInfo API", Version = "v1", Description = "For CustomerInfo API source code - [click here](https://github.com/Kashish3009/CustomerInfo.API), it's open-source :-) Happy exploring....!!." }));
builder.Services.AddDbContext<CustomerInformationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    // to log into the log file in the root path of the project and roll over the logs to another file after 1 day
                    .WriteTo.File("Logs/Customers_Log.txt", rollingInterval: RollingInterval.Day)
                     .MinimumLevel.Information()
                     .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) //comment this line of code when you want to use the swagger UI in production else not
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
