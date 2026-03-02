using Application.Interface;
using Domain.Entities; 
using Application.DTO;

namespace  Application.Services.PropertyCategories
{
    public class PropertyCategoryService : IPropertycategoryService
    { 
     private readonly IPropertyCategory _propertyCategory;
        public PropertyCategoryService(IPropertyCategory propertyCategory)
        {
            _propertyCategory = propertyCategory; 

        }
        public async Task<List<PropertyCategory>> GetAllPropertyCategorysAsync()
        {
            return await _propertyCategory.GetAllPropertyCategorysAsync();
                                
        }
        public async Task <PropertyCategory> GetPropertyCategoryById(int Id)
        {
         return await _propertyCategory.GetPropertyCategoryById(Id);
        }
       public async Task CreatePropertyCategory(PropertyCategoryCreateDTO propertyCategoryDTO)
        {
          await _propertyCategory.CreatePropertyCategory( propertyCategoryDTO);
        }
        public async Task UpdatePropertyCategory(int Id, PropertyCategoryUpdateDTO propertyCategoryDTO)
         {
            await _propertyCategory.UpdatePropertyCategory(Id, propertyCategoryDTO);
         }
    }
}