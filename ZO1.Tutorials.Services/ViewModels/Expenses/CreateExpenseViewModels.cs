using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZO1.Tutorials.Services.ViewModels.Expenses
{
    public class CreateExpenseViewModels
    {
        public CreateExpenseViewModel CreateExpenseViewModel { get; set; }
        public IEnumerable<SelectListItem> ExpenseTypesDropDown { get; set; }
    }
}