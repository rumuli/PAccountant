using Domain.Entities;
using Application.DTO;
namespace Application.Services.Customers
{
    
        public interface ICustomerService
        {
          Customer GetCustomerById(int id);
          
          List<Customer> GetAllCustomers();
//methods
          void CreateCustomer(CreateCustomerDTO customerDTO);

          void UpdateCustomer(int id, UpdateCustomerDTO customerDTO);
          public interface ICustomerService
{
            Task<List<Customer>> GetAllCustomersAsync();
         Task CreateCustomerAsync(CreateCustomerDTO model);
}
        }
    }
