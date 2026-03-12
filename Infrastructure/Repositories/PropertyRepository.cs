
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Properties;
using Microsoft.EntityFrameworkCore;




namespace Infrastructure.Repositories
{
public class PropertyRepository : IProperty

  {
      private readonly ApplicationDbContext dbContext;

        public PropertyRepository(ApplicationDbContext context)
        {
           dbContext= context; 
        }
        // Repository for retrieving accounts data
        public async Task<List<Property>> GetAllPropertysAsync()
        {
          return await dbContext.Properties
          .Include(x=> x.PropertyCategory)
          .ToListAsync();
        }
        public async Task <Property> GetPropertyById(int Id)
        {
            return await dbContext.Properties.FirstOrDefaultAsync(c => c.Id == Id);
        }
       public async Task CreateProperty(PropertyCreateDTO propertyDTO)
        {
             var property = await dbContext.PropertyCategories.FindAsync(propertyDTO.CategoryId);
             var _person = await dbContext.Persons.FindAsync(propertyDTO.PersonId);

            var _property = new Property
            {
                 Person=_person,
                 PropertyCategory = property,
                 Name = propertyDTO.Name,
                 Value = propertyDTO.Value,
                 Location = propertyDTO.Location,
                 AssignedTo = propertyDTO.AssignedTo,
                 PurchasePrice = propertyDTO.PurchasePrice,
                 Identification = propertyDTO.Identification,
                 CreatedBy = "Admin",
                 UpdateBy = "Admin",
                 Status = propertyDTO.Status,
                 PurchaseDate = DateTime.Now,
                 CreatedAt = DateTime.Now,
               
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
                
                await dbContext.SaveChangesAsync();
            }
        }
}}