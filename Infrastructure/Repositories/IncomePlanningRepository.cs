using Infrastructure.Data;
using Application.DTO.IncomePlanning;
// using Application.Services.IncomePlanningServices;
using Application.Interfaces;
using Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories{
    public class IncomePlanningRepository : IIncomePlanning {
        private readonly ApplicationDbContext _context;
        public IncomePlanningRepository(ApplicationDbContext context){
            _context= context;
        }
        public async Task <List<IncomePlanning>> GetIncomePlanningsAsync(){
            return await _context.IncomePlannings
            .Include(x=> x.IncomeType)
            .Include(x =>x.Budget)
            .ToListAsync();
        }
        public async Task AddIncomePlanning(CreateIncomePlanningDTO dto){
            var budget = await _context.Budgets.FindAsync(dto.BudgetId);
            var incometype = await _context.IncomeTypes.FindAsync(dto.IncomeTypeId);
            bool exist = await _context.IncomePlannings.AnyAsync(e => e.Budget.Id == dto.BudgetId && e.IncomeType.Id == dto.IncomeTypeId);  
            if (exist)            
            {
                throw new Exception($"Income planning for this budget and income type already exists.");
            }
            if(budget == null)
            {
                throw new Exception("Budget not found");    
            }
            if(incometype == null)
            {
                throw new Exception("Income type not found");
            }
            
            IncomePlanning newincomeplanning = new  (){
<<<<<<< HEAD
             Budget= await _context.Budgets.FindAsync(dto.BudgetId),
             IncomeType= await _context.IncomeTypes.FindAsync(dto.IncomeTypeId),
=======
             Budget= budget,
             IncomeType= incometype,
>>>>>>> BudgetPlanning
             Amount= dto.Amount,
             Description= dto.Description,
             CreatedAt= DateTime.Now,
             UserAdded= 1,
             UpdatedAt= DateTime.Now
           };
            budget.PlannedIncome += dto.Amount;
           _context.IncomePlannings.Add(newincomeplanning);
           await _context.SaveChangesAsync();
        }
    }
}