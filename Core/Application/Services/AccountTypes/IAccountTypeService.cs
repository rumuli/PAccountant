using Domain.Entities;
using Application.DTO;

namespace Application.Interface
{
   public interface IAccountTypeService
    {
       Task <AccountType> GetAcountTypeById(int Id);
       Task <List<AccountType>> GetAllAccountTypes();
        Task CreateAccountType(AccountTypeCreateDTO accounttypeDTO);
        Task UpdateAccountType(int Id, AccountTypeUpdateDTO accounttypeDTO);
    }
}