using Application.Interface;
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
namespace Infrastructure.Repositories
{
    public class PersonRepository : IPerson
    {
        private readonly ApplicationDbContext dbContext;
        public PersonRepository(ApplicationDbContext context)
        {
           dbContext=context; 
        }
        // Repository for retrieving ticket data
        public  List<Person> GetAllPersons()
        {
          List<Person> _person = dbContext.Persons.ToList();
          return _person;
        }
        public Person GetPersonById(int Id)
        {
            return  dbContext.Persons.FirstOrDefault(t => t.Id == Id);
        }
         public void CreatePerson(PersonCreateDTO personDTO)
        {
            var _person = new Person
            {
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                Sex = personDTO.Sex,
                Status = personDTO.Status,
                DateOfBirth = DateTime.Now,
                phoneNumber = personDTO.phoneNumber,
                Email = personDTO.Email,
                Country = personDTO.Country,
                City = personDTO.City,
                Street = personDTO.Street,
                CreatedBy="Admin", 
                UpdateBy="Admin"          

            };
            dbContext.Persons.Add(_person);
            dbContext.SaveChanges();
        }

        public void UpdatePerson(int Id,PersonUpdateDTO personDTO)
        {
            var _person = dbContext.Persons.Find(Id);
            if (_person != null)
            {
                _person.FirstName = personDTO.FirstName;
                _person.LastName = personDTO.LastName;
                _person.Sex = personDTO.Sex;
                _person.Country = personDTO.Country;
                _person.City = personDTO.City;
                _person.Street = personDTO.Street;
                dbContext.SaveChanges();
            }
        }
    }
    }   
    
    
        