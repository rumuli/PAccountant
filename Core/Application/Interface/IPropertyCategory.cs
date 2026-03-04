using Domain.Entities;
using Application.DTO;

namespace Application.Interface
{
   public interface IPropertyCategory
    {
       Task <PropertyCategory> GetPropertyCategoryById(int Id);
       Task <List<PropertyCategory>> GetAllPropertyCategorysAsync();
        Task CreatePropertyCategory(PropertyCategoryCreateDTO propertyCategoryDTO);
        Task UpdatePropertyCategory(int Id, PropertyCategoryUpdateDTO propertyCategoryDTO);
    }
}