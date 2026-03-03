using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
   public  interface IProperty
    {
       
       Task <Property> GetPropertyById(int Id);
       Task <List<Property>> GetAllPropertysAsync();
        Task CreateProperty(PropertyCreateDTO propertyDTO);
        Task UpdateProperty(int Id, PropertyUpdateDTO propertyDTO);
    }
}