using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Write([FromQuery] string username, [FromQuery] int userid)
        {
            HttpContext.Session.SetString("username",username);
            HttpContext.Session.SetInt32("userid",userid);
            return View();
        }

        public IActionResult Read([FromQuery] int? userid)
        {
            string username = HttpContext.Session.GetString("username");
            userid = HttpContext.Session.GetInt32("userid");

            Tuple<string, int?> tuple = new Tuple<string, int?>(username,userid);
            return View("Read",tuple);
        }
    }
}