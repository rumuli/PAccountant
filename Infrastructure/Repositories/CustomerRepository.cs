using Domain.Entities;
using Application.Interfaces;
using Application.Services.Customers;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
using Application.DTO;

namespace Infrastructure.Repositories
{
    
        // Retrieving customers
        public class CustomerRepository : ICustomer
        {
            private readonly ApplicationDbContext _dbContext;
            public CustomerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
            public List<Customer> GetAllCustomers()
        {
              List<Customer> _customers = _dbContext.Customers.ToList();

            return _customers;
        }

        public Customer GetCustomerById(int id)
        { 
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);    
        }
        //create and update method
        public void CreateCustomer(CreateCustomerDTO customerDTO)
        {
            Customer customer = new()
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Address = customerDTO.Address,
                City = customerDTO.City,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedById = 1

                
                



                //you can put create date isactive=true
            };
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
        public void UpdateCustomer(int id, UpdateCustomerDTO customerDTO)
        {
            Customer customer = _dbContext.Customers.Find(id);
            if (customer == null) return;
            
                customer.Name = customerDTO.Name;
                customer.Phone = customerDTO.Phone;
                customer.Address = customerDTO.Address;
                customer.City = customerDTO.City;
                _dbContext.SaveChanges();
            }
        }
        }


    