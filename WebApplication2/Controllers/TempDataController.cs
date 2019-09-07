using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult First()
        {
            TempData["Title"] = "First";
            TempData["Title2"] = "First";

            ViewBag.Page = "First";


            TempDataDto tempDataDto = new TempDataDto();

            return View("Ortak", tempDataDto);
        }

        public IActionResult Second()
        {
            string val = TempData.Peek("Title")?.ToString();// TempData["First"] boş değilse tosting e çevir.
            string val2 = TempData["Title2"]?.ToString();
            ViewBag.Page = "Second";

            TempDataDto tempDataDto = new TempDataDto()
            {
                Title = val,
                Title2 = val2
            };

            return View("Ortak", tempDataDto);
        }

        public IActionResult third()
        {
            string val = TempData["Title"]?.ToString();
            string val2 = TempData["Title2"]?.ToString();
            ViewBag.Page = "third";
            TempDataDto tempDataDto = new TempDataDto()
            {
                Title = val,
                Title2 = val2
            };

            return View("Ortak", tempDataDto);
        }
    }


    public class TempDataDto
    {
        public string Title { get; set; }
        public string Title2 { get; set; }
    }
}