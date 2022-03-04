using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZO1.Tutorials.Services.Results;
using ZO1.Tutorials.Services.ViewModels.ExpenseTypes;

namespace ZO1.Tutorials.Services.Services.Interface
{
    public interface IExpenseTypeService
    {
        ResponseResult CreateExpenseType(CreateExpenseTypeViewModel model);
        ResponseResult UpdateExpenseType(CreateExpenseTypeViewModel model);
        ResponseResult DeleteExpenseType(int id);


        IEnumerable<CreateExpenseTypeViewModel> GetAllExpenseTypes();


        IEnumerable<SelectListItem> GetAllExpenseTypesDropDown();


        CreateExpenseTypeViewModel GetExpenseTypeById(int id);
    }
}