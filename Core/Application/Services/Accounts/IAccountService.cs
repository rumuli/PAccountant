using Domain.Entities;
using Application.DTO;

namespace Application.Services.Accounts
{
    public interface IAccountService
    {
        Task <Account> GetAcountById(int Id);
        Task <List<Account>> GetAllAccountsAsync();
        Task CreateAccount(AccountCreateDTO accountDTO);
        Task UpdateAccount(int Id, AccountUpdateDTO accountDTO);
    }
}