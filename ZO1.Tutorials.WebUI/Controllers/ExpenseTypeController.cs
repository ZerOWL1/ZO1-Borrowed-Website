using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZO1.Tutorials.Services.Services.Interface;
using ZO1.Tutorials.Services.ViewModels.ExpenseTypes;

namespace ZO1.Tutorials.WebUI.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }

        // GET
        public IActionResult Index()
        {
            var expenseTypes = _expenseTypeService.GetAllExpenseTypes().ToList();
            return View(expenseTypes);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateExpenseTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _expenseTypeService.CreateExpenseType(model);
            if (result.IsSuccess)
            {
                TempData["SuccessMess"] = $"Add ExpenseType '{model.Name}' success";
                return RedirectToAction("Index");
            }

            TempData["FailMess"] = $"Add ExpenseType '{model.Name}' fail";
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var expenseTypes = _expenseTypeService.GetExpenseTypeById(id);
            return View(expenseTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CreateExpenseTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _expenseTypeService.UpdateExpenseType(model);
            if (result.IsSuccess)
            {
                TempData["SuccessMess"] = $"Update ExpenseType '{model.Name}' success";
                return RedirectToAction("Index");
            }

            TempData["FailMess"] = $"Update ExpenseType '{model.Name}' fail";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _expenseTypeService.DeleteExpenseType(id);
            if (result.IsSuccess)
            {
                TempData["SuccessMess"] = "Delete ExpenseType success";
                return RedirectToAction("Index");
            }

            TempData["FailMess"] = "Delete ExpenseType fail";
            return RedirectToAction("Index");
        }

    }
}