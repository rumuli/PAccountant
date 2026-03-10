using Domain.Entities;
using Application.DTO;

namespace Application.Services.Properties
{
   public interface IPropertyService
    {
       Task <Property> GetPropertyById(int Id);
       Task <List<Property>> GetAllPropertysAsync();
        Task CreateProperty(PropertyCreateDTO propertyDTO);
        Task UpdateProperty(int Id, PropertyUpdateDTO propertyDTO);
    }
}