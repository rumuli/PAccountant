using Domain.Entities;
using Application.DTO;

namespace Application.Services.AccountTypes
{
   public interface IAccountTypeService
    {
       Task <AccountType> GetAcountTypeById(int Id);
       Task <List<AccountType>> GetAllAccountTypes();
        Task CreateAccountType(AccountTypeCreateDTO accounttypeDTO);
        Task UpdateAccountType(int Id, AccountTypeUpdateDTO accounttypeDTO);
    }
}