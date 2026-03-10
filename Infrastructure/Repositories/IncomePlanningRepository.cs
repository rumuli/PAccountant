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
             IncomePlanning newincomeplanning = new  (){
             Budget= await _context.Budgets.FindAsync(dto.BudgetId),
             IncomeType= await _context.IncomeTypes.FindAsync(dto.IncomeTypeId),
             Amount= dto.Amount,
             Description= dto.Description,
             CreatedAt= DateTime.Now,
             UserAdded= 1,
             UpdatedAt= DateTime.Now
           };
           _context.IncomePlannings.Add(newincomeplanning);
           await _context.SaveChangesAsync();
        }
    }
}