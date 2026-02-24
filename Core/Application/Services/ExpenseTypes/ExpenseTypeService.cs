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
    public ExpenseType GetExpenseTypeById(int id)
    {
        return _expenseType.GetExpenseTypeById(id);
    }
    public List<ExpenseType> GetAllExpenseTypes()
    {
        List<ExpenseType> expenseTypes = _expenseType.GetAllExpenseTypes();
        return expenseTypes;
    }
public void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO)
   {
        _expenseType.CreateExpenseType(expenseTypeDTO);
   }

}

    public interface IExpenseType
    {
        void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO);
        List<ExpenseType> GetAllExpenseTypes();
        ExpenseType GetExpenseTypeById(int id);
    }
}