using Domain.Entities;
using Application.DTO;

namespace Application.Services.PropertyCategories
{
   public interface IPropertycategoryService
    {
    Task <PropertyCategory> GetPropertyCategoryById(int Id);
    Task <List<PropertyCategory>> GetAllPropertyCategorysAsync();
    Task CreatePropertyCategory(PropertyCategoryCreateDTO propertyCategoryDTO);
    Task UpdatePropertyCategory(int Id, PropertyCategoryUpdateDTO propertyCategoryDTO);
    }
}