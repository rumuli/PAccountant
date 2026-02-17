using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);

        void CreateCustomer(CreateCustomerDTO customerDTO);
        void UpdateCustomer(int id, UpdateCustomerDTO customerDTO);
    }
}