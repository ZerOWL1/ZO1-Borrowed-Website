using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZO1.Tutorials.Services.Services.Interface;
using ZO1.Tutorials.Services.ViewModels.Items;

namespace ZO1.Tutorials.WebUI.Controllers
{
    public class ItemController : Controller
    {
        // GET
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var items = _itemService.GetAllItem().ToList();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _itemService.CreateItem(model);
            if (result.IsSuccess)
            {
                TempData["SuccessMess"] = $"Add Item '{model.ItemName}' Success";
                return RedirectToAction("Index");
            }

            TempData["FailMess"] = $"Add Item '{model.ItemName}' Fail";
            return RedirectToAction("Index");
        }
    }
}