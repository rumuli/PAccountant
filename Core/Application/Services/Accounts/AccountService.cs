using Application.Interface;
using Domain.Entities; 
using Application.DTO;

namespace  Application.Services.Accounts
{
    public class AccountService : IAccountService
    { 
     private readonly IAccount _account;
        public AccountService(IAccount accounts)
        {
            _account = accounts;

        }
         public async Task<List<Account>> GetAllAccountsAsync()
        {
         return await _account.GetAllAccountsAsync();
        }
         public async Task<Account> GetAcountById(int Id)
        {
            return await _account.GetAcountById(Id);
        }
       public async Task CreateAccount(AccountCreateDTO accountDTO)
        {
            await _account.CreateAccount( accountDTO);
        }
      public async Task UpdateAccount(int Id, AccountUpdateDTO accountDTO)
        {
            await _account.UpdateAccount(Id, accountDTO);
        }
    }
}