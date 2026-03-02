
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Application.Interface;
using Application.Services.AccountTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
public class AccountTypeRepository : IAccountType

  {
      private readonly ApplicationDbContext dbContext;

        public AccountTypeRepository(ApplicationDbContext context)
        {
           dbContext= context; 
        }
        // Repository for retrieving accounts data
        public async Task<List<AccountType>> GetAllAccountTypes()
        {
          return await dbContext.AccountTypes.ToListAsync();
        }
        public async Task <AccountType> GetAcountTypeById(int Id)
        {
            return await dbContext.AccountTypes.FirstOrDefaultAsync(c => c.Id == Id);
        }
       public async Task CreateAccountType(AccountTypeCreateDTO accounttypeDTO)
        {
            var accounttype = new AccountType
            {
                Name = accounttypeDTO.Name,
                 Status = accounttypeDTO.Status,
                CreatedBy = "Admin",
                UpdateBy = "Admin", // ADD THIS LINE: It cannot be NULL in the database
                CreatedAt = DateTime.Now,
               
            };
            await dbContext.AccountTypes.AddAsync(accounttype);
            await dbContext.SaveChangesAsync();
            
        }
        public async Task UpdateAccountType(int Id,AccountTypeUpdateDTO accounttypeDTO)
        {
            var accounttype = dbContext.AccountTypes.Find(Id);
            if (accounttype != null)
            {
                accounttype.Name = accounttypeDTO.Name;
                accounttype.Status = accounttypeDTO.Status;
                accounttype.CreatedAt = DateTime.Now;
                accounttype.UpdateBy = "Admin";
                
                await dbContext.SaveChangesAsync();
            }
        }
}}