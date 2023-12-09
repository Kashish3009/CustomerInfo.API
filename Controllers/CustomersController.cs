using AutoMapper;
using CustomerInfo.API.CustomActionFilters;
using CustomerInfo.API.DTOs.CustomerDTO;
using CustomerInfo.API.Models;
using CustomerOrders.API.DTOs.CustomerDTO;
using CustomerOrders.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        private readonly ILogger<CustomersController> logger;

        public CustomersController(IMapper mapper, ICustomerRepository customerRepository, ILogger<CustomersController> logger)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            this.logger = logger;
        }

        // This endpoint CREATE Customers
        // POST: api/customers
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CustomerRequest customerRequest)
        {
            try
            {
                logger.LogInformation("Customer creation started");
                var customerModel = mapper.Map<Customer>(customerRequest);
                await customerRepository.CreateAsync(customerModel);
                logger.LogInformation("Customer created Successfully");
                var customerResponse = mapper.Map<CustomerResponse>(customerModel);
                return CreatedAtAction(nameof(GetById), new { id = customerResponse.CustomerId }, customerResponse);
            }
            catch (Exception ex)
            {
                logger.LogCritical(500, ex, ex.StackTrace);
                throw;
            }
        }

        // This endpoint GET Customers
        // GET: api/customers
        // GET: /api/customers?filterOn=FirstName&filterQuery=Kashish&sortBy=LastName&isAscending&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? filterOn,
                                                [FromQuery] string? filterQuery,
                                                [FromQuery] string? sortBy,
                                                [FromQuery] bool? isAscending,
                                                [FromQuery] int pageNumber = 1,
                                                [FromQuery] int pageSize = 1000)
        {
            try
            {
                logger.LogInformation("Starting to get all the customers");
                var customerModel = await customerRepository.GetAllAsync(filterOn, filterQuery,sortBy, isAscending ?? true, pageNumber, pageSize);
                logger.LogInformation("Fetched all the customers");
                return Ok(mapper.Map<List<CustomerResponse>>(customerModel));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // This endpoint GET Customer by Id
        // GET: /api/customers/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                logger.LogInformation($"Starting to fetch the customer with id:{(id)}");
                var customerModel = await customerRepository.GetByIdAsync(id);
                if (customerModel == null)
                {
                    logger.LogInformation($"Customer with id:{(id)} is not available for showing");
                    return NotFound();
                }
                logger.LogInformation($"Customer with id:{(id)} is fetched successfully");
                return Ok(mapper.Map<CustomerResponse>(customerModel));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // This endpoint UPDATE customer by Id
        // PUT: /api/customers/{id}
        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCustomer updateCustomer)
        {
            try
            {
                logger.LogInformation($"Starting to update the information for customer with id:{(id)}");
                var customerModel = mapper.Map<Customer>(updateCustomer);
                await customerRepository.UpdateAsync(id, customerModel);
                if (customerModel == null)
                {
                    logger.LogInformation($"Customer with id:{(id)} is not in the database for updation");
                    return NotFound();
                }
                logger.LogInformation($"Updated the customer information with id:{(id)} successfully");
                return Ok(mapper.Map<CustomerResponse>(customerModel));
            }
            catch (Exception ex)
            {
                logger.LogTrace(500, ex, ex.StackTrace);
                throw;
            }
        }

        // This endpoint DELETE a custmer by id
        // DELETE: /api/customers/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                logger.LogInformation($"Attempting to delete the customer with Id:{(id)}");
                var customerModel = await customerRepository.DeleteAsync(id);

                if (customerModel == null)
                {
                    logger.LogInformation($"Customer with Id:{(id)} is not in the database for deletion");
                    return NotFound();
                }
                logger.LogInformation($"Deleted the customer with id: {(id)} successfully");
                return Ok(mapper.Map<CustomerResponse>(customerModel));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
