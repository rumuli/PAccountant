 // This points to YOUR interface
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Repositories
{
public class AccountRepository : IAccount

  {
      private readonly ApplicationDbContext dbContext;

        public AccountRepository(ApplicationDbContext context)
        {
           dbContext= context; 
        }
       
        public async Task<List<Account>> GetAllAccountsAsync()
       {
         return await dbContext.Accounts
        .Include(a => a.AccountType) 
        .ToListAsync();
      }
        public async Task <Account> GetAcountById(int Id)
        {
            return  dbContext.Accounts.FirstOrDefault(c => c.Id == Id);
       }
       public async Task CreateAccount(AccountCreateDTO accountDTO)
        {
            var accountType = await dbContext.AccountTypes.FindAsync(accountDTO.AccountTypeId);
        
            var accounts = new Account
            {
                AccountType = accountType,
                AccountNumber = accountDTO.AccountNumber,
                Provider = accountDTO.Provider,
                Balance = accountDTO.Balance,
                Status = accountDTO.Status,
                CreatedBy = "Admin",
                UpdateBy="Admin",
                CreatedAt = DateTime.Now,  

            };
            dbContext.Accounts.Add(accounts);
            dbContext.SaveChanges();
        }
        public async Task UpdateAccount(int Id,AccountUpdateDTO accountDTO)
        {
            var account = dbContext.Accounts.Find(Id);
            if (account != null)
            {
                account.AccountNumber = accountDTO.AccountNumber;
                account.Provider = accountDTO.Provider;
                account.Balance = accountDTO.Balance;
                account.Status = accountDTO.Status;
                account.UpdateBy = "Admin";
                dbContext.SaveChanges();
            }
        }
}}