
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Application.Interfaces;
using Application.Services.PropertyCategories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
public class PropertyCategoryRepository : IPropertyCategory

  {
      private readonly ApplicationDbContext dbContext;

        public PropertyCategoryRepository(ApplicationDbContext context)
        {
           dbContext= context; 
        }
        // Repository for retrieving accounts data
        public async Task<List<PropertyCategory>> GetAllPropertyCategorysAsync()
        {
          return await dbContext.PropertyCategories.ToListAsync();
        }
        public async Task <PropertyCategory> GetPropertyCategoryById(int Id)
        {
            return await dbContext.PropertyCategories.FirstOrDefaultAsync(c => c.Id == Id);
        }
       public async Task CreatePropertyCategory(PropertyCategoryCreateDTO propertyCategoryDTO)
        {
            var propertycategory = new PropertyCategory
            {
                Name = propertyCategoryDTO.Name,
                 Status = propertyCategoryDTO.Status,
                CreatedBy = "Admin",
                UpdateBy = "Admin", // ADD THIS LINE: It cannot be NULL in the database
                CreatedAt = DateTime.Now,
               
            };
            await dbContext.PropertyCategories.AddAsync(propertycategory);
            await dbContext.SaveChangesAsync();
            
        }
        public async Task UpdatePropertyCategory(int Id,PropertyCategoryUpdateDTO propertyCategoryDTO)
        {
            var propertycategory = dbContext.PropertyCategories.Find(Id);
            if (propertycategory != null)
            {
                propertycategory.Name = propertyCategoryDTO.Name;
                propertycategory.Status = propertyCategoryDTO.Status;
                propertycategory.CreatedAt = DateTime.Now;
                propertycategory.UpdateBy = "Admin";
                
                await dbContext.SaveChangesAsync();
            }
        }
}}