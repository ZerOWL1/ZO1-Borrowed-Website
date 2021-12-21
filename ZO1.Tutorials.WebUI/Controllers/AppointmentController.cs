using Microsoft.AspNetCore.Mvc;
using System;

namespace ZO1.Tutorials.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var todayDate = DateTime.Now.ToString("dd MMM yyyy - HH:mm:ss tt");
            return View((object)todayDate);
        }

        public IActionResult Details(int id)
        {
            var @string = $"You've entered id = {id}";

            return Ok(@string);
        }
    }
}   