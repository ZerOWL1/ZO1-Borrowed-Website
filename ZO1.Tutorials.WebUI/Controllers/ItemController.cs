using Microsoft.AspNetCore.Mvc;
using ZO1.Tutorials.Services.Services.Interface;

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
            var items = _itemService.GetAllItem();


            return View();
        }
    }
}