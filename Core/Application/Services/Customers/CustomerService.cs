using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Application.Interfaces;
using Application.Services.Customers;   
using Application.DTO;


namespace Application.Services.Customers
{


    public class CustomerService : ICustomerService 

        { 
            private readonly ICustomer _customer; 

            public  CustomerService(ICustomer customer)
            {
                _customer = customer;
            }

             public Customer GetCustomerById(int id)
            {
                return _customer.GetCustomerById(id);
            }  

            public List<Customer> GetAllCustomers()
            {
                List<Customer> customers = _customer.GetAllCustomers();
                return customers;
            }
            public void CreateCustomer(CreateCustomerDTO customerDTO)
            {
                _customer.CreateCustomer(customerDTO);
            }

            public void UpdateCustomer(int id, UpdateCustomerDTO customerDTO)
            {
                _customer.UpdateCustomer(id, customerDTO);
            }
            
            

        }

    public interface ICustomer
    {
        void CreateCustomer(CreateCustomerDTO customerDTO);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(int id, UpdateCustomerDTO customerDTO);
    }
   
}


    

    
        
    
