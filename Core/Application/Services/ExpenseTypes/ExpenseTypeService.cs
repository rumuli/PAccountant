using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.ExpenseTypes;



namespace Application.Services.ExpenseTypes
{
    public class ExpenseTypeService : IExpenseTypeService
{
    private readonly IExpenseType _expenseType;
    public ExpenseTypeService(IExpenseType expenseType)
    {
        _expenseType = expenseType;
    }
    public async Task<List<ExpenseType>> GetAllExpenseTypesAsync()
    {
        return await _expenseType.GetAllExpenseTypesAsync();
    }
    public ExpenseType GetExpenseTypeById(int id)
    {
        return _expenseType.GetExpenseTypeById(id);
    }

public void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO)
   {
        _expenseType.CreateExpenseType(expenseTypeDTO);
   }

}
}