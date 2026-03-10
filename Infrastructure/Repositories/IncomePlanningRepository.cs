using Infrastructure.Data;
using Application.DTO.IncomePlanning;
// using Application.Services.IncomePlanningServices;
using Application.Interfaces;
using Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;
namespace Infrastructure.Repositories{
    public class IncomePlanningRepository : IIncomePlanning {
        private readonly ApplicationDbContext _context;
        public IncomePlanningRepository(ApplicationDbContext context){
            _context= context;
        }
        public async Task <List<IncomePlanning>> GetIncomePlanningsAsync(){
            return await _context.IncomePlannings
            // .Include(x=> x.IncomeType)
            // .Include(x =>x.Budget)
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
             Budget= await _context.Budgets.FindAsync(dto.BudgetId),
             IncomeType= await _context.IncomeTypes.FindAsync(dto.IncomeTypeId),
             Amount= dto.Amount,
             Description= dto.Description,
             CreatedAt= DateTime.Now,
             UserAdded= 1,
             UpdatedAt= DateTime.Now
           };
            budget.PlannedIncome += dto.Amount;
            budget.Status= BudgetStatus.Running;
           _context.IncomePlannings.Add(newincomeplanning);
           _context.Entry(budget).Property(x => x.Status).IsModified = true;
           await _context.SaveChangesAsync();
        }
        public async Task <List<IncomePlanning>> GetSummaryIncomePlanningAsync(int BudgetId)
        {
            return await _context.IncomePlannings
            .Include(x => x.IncomeType)
            .Where(x=>x.Budget.Id == BudgetId)
            .GroupBy(x=> x.IncomeType.Id)
            .Select(g => new IncomePlanning
            {
                BudgetId= g.FirstOrDefault().Budget.Id,
                IncomeTypeId= g.FirstOrDefault().IncomeType.Id,
                Amount= g.Sum(x=> x.Amount),
                IncomeType = g.FirstOrDefault().IncomeType
            })
            .ToListAsync();
        }        
    }
}