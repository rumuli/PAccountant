using Application.Interfaces;
using Domain.Entities; 
using Application.DTO;


namespace  Application.Services.AccountTypes
{
    public class AccountTypeService : IAccountTypeService
    { 
     private readonly IAccountType _accounttype;
        public AccountTypeService(IAccountType accounttypes)
        {
            _accounttype = accounttypes; 

        }
        public async Task<List<AccountType>> GetAllAccountTypes()
        {
            return await _accounttype.GetAllAccountTypes();
                                
        }
        public async Task <AccountType> GetAcountTypeById(int Id)
        {
         return await _accounttype.GetAcountTypeById(Id);
        }
       public async Task CreateAccountType(AccountTypeCreateDTO accounttypeDTO)
        {
          await _accounttype.CreateAccountType( accounttypeDTO);
        }
        public async Task UpdateAccountType(int Id, AccountTypeUpdateDTO accounttypeDTO)
         {
            await _accounttype.UpdateAccountType(Id, accounttypeDTO);
         }
    }
}