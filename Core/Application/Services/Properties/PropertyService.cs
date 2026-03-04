using Application.Interfaces;
using Domain.Entities; 
using Application.DTO;

namespace  Application.Services.Properties
{
    public class PropertyService : IPropertyService
    { 
     private readonly IProperty _property;
        public PropertyService(IProperty properties)
        {
            _property = properties;

        }
         public async Task<List<Property>> GetAllPropertysAsync()
        {
         return await _property.GetAllPropertysAsync();
        }
         public async Task<Property> GetPropertyById(int Id)
        {
            return await _property.GetPropertyById(Id);
        }
       public async Task CreateProperty(PropertyCreateDTO propertyDTO)
        {
            await _property.CreateProperty( propertyDTO);
        }
      public async Task UpdateProperty(int Id, PropertyUpdateDTO propertyDTO)
        {
            await _property.UpdateProperty(Id, propertyDTO);
        }

       
    }
}