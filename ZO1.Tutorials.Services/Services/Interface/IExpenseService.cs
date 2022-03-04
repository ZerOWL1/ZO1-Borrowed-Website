using System.Collections.Generic;
using ZO1.Tutorials.Services.Results;
using ZO1.Tutorials.Services.ViewModels.Expenses;

namespace ZO1.Tutorials.Services.Services.Interface
{
    public interface IExpenseService
    {
        ResponseResult CreateExpense(CreateExpenseViewModel model);
        ResponseResult UpdateExpense(CreateExpenseViewModel model);
        ResponseResult DeleteExpense(int id);



        IEnumerable<CreateExpenseViewModel> GetAllExpenses();
        IEnumerable<CreateExpenseViewModel> GetExpensesWithExpenseType();


        CreateExpenseViewModel GetExpenseById(int id);
    }
}