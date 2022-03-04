using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ZO1.Tutorials.Services.Services.Interface;
using ZO1.Tutorials.Services.ViewModels.Expenses;

namespace ZO1.Tutorials.WebUI.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseController(IExpenseService expenseService
            , IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
            _expenseService = expenseService;
        }

        // GET
        public IActionResult Index()
        {
            var expenses = _expenseService.GetExpensesWithExpenseType().ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            var createExpenseTypesVm = new CreateExpenseViewModels
            {
                ExpenseTypesDropDown = _expenseTypeService.GetAllExpenseTypesDropDown()
            };

            return View(createExpenseTypesVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateExpenseViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _expenseService.CreateExpense(model.CreateExpenseViewModel);
            if (result.IsSuccess)
            {
                TempData["SuccessMess"] = $"Add Expense '{model.CreateExpenseViewModel.ExpenseName}' Success";
                return RedirectToAction("Index");
            }

            TempData["FailMess"] = $"Add Expense '{model.CreateExpenseViewModel.ExpenseName}' Fail";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var expense = _expenseService.GetExpenseById(id);
            if (expense != null)
            {
                var createExpenseTypesVm = new CreateExpenseViewModels
                {
                    CreateExpenseViewModel = expense,
                    ExpenseTypesDropDown = _expenseTypeService.GetAllExpenseTypesDropDown()
                };
                return View(createExpenseTypesVm);
            }

            TempData["FailMess"] = "Can't found any Expense match with";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CreateExpenseViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _expenseService.UpdateExpense(model.CreateExpenseViewModel);
            if (result != null)
            {
                TempData["SuccessMess"] = $"Update Expense '{model.CreateExpenseViewModel.ExpenseName}' Success";
                return RedirectToAction("Index");
            }

            TempData["FailMess"] = $"Update Expense '{model.CreateExpenseViewModel.ExpenseName}' Fail";
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var result = _expenseService.DeleteExpense(id);

            if (result.IsSuccess)
            {
                TempData["SuccessMess"] = "Delete Expense Success";
                return RedirectToAction("Index");
            }
            TempData["FailMess"] = "Delete Expense Fail";
            return RedirectToAction("Index");
        }
    }
}