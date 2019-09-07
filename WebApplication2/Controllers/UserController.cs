using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginAction([FromQuery] string username)
        {
            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            };

            Response.Cookies.Append("username",username, cookieOptions);

            return View("Login"); 
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("username");
            return View("Login");
        }

        public IActionResult MemberArea()
        {
            string username = Request.Cookies["username"];
            return View("MemberArea",username);
        }
    }
}
