using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using routeIs.Models;

namespace routeIs.Controllers
{
    public class UserController : Controller
    {
        ApplicationContext db;
        //public IActionResult Index()
        //{
        //    var user = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
        //    //user?.FirstOrDefault(x => x.Type.Equals("Surname", StringComparison.OrdinalIgnoreCase))?.Value;
        //    return View();
        //}
        public IActionResult Index()
        {
            return View(User.Identity.Name);
        }

    }
}