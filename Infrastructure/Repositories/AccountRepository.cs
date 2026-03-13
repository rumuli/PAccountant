
 // This points to YOUR interface
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity;


namespace Infrastructure.Repositories
{
public class AccountRepository : IAccount

  {
      private readonly ApplicationDbContext dbContext;
      private readonly UserContext _userContext;

        public AccountRepository(ApplicationDbContext context, UserContext userContext)
        {
           dbContext= context; 
           _userContext = userContext;
        }
       
        public async Task<List<Account>> GetAllAccountsAsync()
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }

            // Logic: Get accounts where the PersonId matches the PersonId of the Current User
            return await dbContext.Users
                .Where(u => u.Id == _userContext.Id)
                .SelectMany(u => u.Person.Accounts)
                .Include(a => a.AccountType)
                .ToListAsync();
        }
        public async Task <Account> GetAcountById(int Id)
        {
            return  dbContext.Accounts.FirstOrDefault(c => c.Id == Id);
       }
       public async Task CreateAccount(AccountCreateDTO accountDTO)
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }

            // Fix: We need the PersonId linked to this User, not the UserId itself
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == _userContext.Id);

            if (user == null)
            {
                throw new Exception("User record not found");
            }

            var accountType = await dbContext.AccountTypes.FindAsync(accountDTO.AccountTypeId);

            var account = new Account
            {
                AccountType = accountType,
                AccountNumber = accountDTO.AccountNumber,
                Provider = accountDTO.Provider,
                // Logic Fix: Assign the PersonId from the User record
                PersonId = user.PersonId, 
                Balance = accountDTO.Balance,
                InitialBalance = accountDTO.Balance, // Good practice to set this too
                Status = accountDTO.Status,
                CreatedBy = user.UserName ?? "System",
                UpdateBy = user.UserName ?? "System",
                CreatedAt = DateTime.Now,
            };

            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync(); // Use Async!
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
                account. UpdateBy = _userContext.FullName ?? "System";
                dbContext.SaveChanges();
            }
        }
}}
