using Application.DTO;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Interfaces
{
    public interface IIdentity
    {
         Task RegisterUser (RegisterUserDTO dto);
         Task<List<UserDetailDTO>> GetAllUsers();
            Task<UserDetailDTO> GetUserById(int id);
            Task UpdateUser(int id, UserDetailDTO dto);
            Task<bool> LoginAsync(LoginDTO dto);
            Task LogoutAsync();
    }
    }   
 