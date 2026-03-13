
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Properties;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity;




namespace Infrastructure.Repositories
{
public class PropertyRepository : IProperty

  {
      private readonly ApplicationDbContext dbContext ;
      private readonly UserContext _userContext;

        public PropertyRepository(ApplicationDbContext context, UserContext userContext)
        {
           dbContext= context; 
           _userContext= userContext; 
        }
        
        // Repository for retrieving accounts data
        public async Task<List<Property>> GetAllPropertysAsync()
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }


                return await dbContext.Properties
                .Where(u => u.Id == _userContext.Id)
                .SelectMany(u => u.Person.Properties)
                .Include(a => a.PropertyCategory)
                .ToListAsync();
        }
        public async Task <Property> GetPropertyById(int Id)
        {
            return await dbContext.Properties.FirstOrDefaultAsync(c => c.Id == Id);
        }
       public async Task CreateProperty(PropertyCreateDTO propertyDTO)
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }

            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == _userContext.Id);
            if (user == null)
            {
                throw new Exception("User record not found");
            }
            

             var property = await dbContext.PropertyCategories.FindAsync(propertyDTO.CategoryId);
             var _person = await dbContext.Persons.FindAsync(propertyDTO.PersonId);


            var _property = new Property
            {
                 PersonId = user.PersonId, 
                 PropertyCategory = property,
                 Name = propertyDTO.Name,
                 Value = propertyDTO.Value,
                 Location = propertyDTO.Location,
                 AssignedTo = propertyDTO.AssignedTo,
                 PurchasePrice = propertyDTO.PurchasePrice,
                 Identification = propertyDTO.Identification,
                 CreatedBy = user.UserName ?? "System",
                 UpdateBy = user.UserName ?? "System",
                 Status = propertyDTO.Status,
                 PurchaseDate = DateTime.Now,
                 CreatedAt = DateTime.Now,
                    Manufacturer = propertyDTO.Manufacturer
               
            };
            await dbContext.Properties.AddAsync(_property);
            await dbContext.SaveChangesAsync();
            
        }
        public async Task UpdateProperty(int Id,PropertyUpdateDTO propertyDTO)
        {
            var _property = dbContext.Properties.Find(Id);
            if (_property != null)
            {
              
                _property.Name = propertyDTO.Name;
                _property.Value = propertyDTO.Value;
                _property.Location = propertyDTO.Location;
                _property.AssignedTo = propertyDTO.AssignedTo;
                _property.PurchasePrice = propertyDTO.PurchasePrice;
                _property.Identification = propertyDTO.Identification;
                _property.PurchaseDate = DateTime.Now;
                _property.UpdateBy = "Admin";
                _property.Manufacturer = propertyDTO.Manufacturer;
                
                await dbContext.SaveChangesAsync();
            }
        }
}}