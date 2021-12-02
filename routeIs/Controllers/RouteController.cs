using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using routeIs.Models;

namespace routeIs.Controllers
{
    public class RouteController : Controller
    {
        ApplicationContext db;
        public IActionResult Index()    //вывод маршрутов авторизованного пользователя
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            int id = Convert.ToInt32(currentUserID);
            IEnumerable<Route> route = db.Routes.Where(x => x.UserId == id).ToList();
            return View(route);
        }
        //[HttpGet]
        //public IActionResult CreateRoute(List<string> names)
        //{
        //    List<int> localId = new List(); //список айди точек
        //    Locality local = new Locality();
        //    foreach (string item in names)
        //    {
        //        local.Name = item;
        //        db.Localities.Add(local);
        //        db.SaveChanges();
        //        List.Add(local.Id);
        //    }
        //    ViewBag.localId = localId; //передаём список айди для последующего использования
        //    return View();
        //}

        [HttpPost]
        public IActionResult CreateRoute(Route route, List<int> localId)
        {
            // находим туриста с авторизованным ником
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            int id = Convert.ToInt32(currentUserID);
            route.UserId = id;
            route.DateOfCreate = DateTime.Now; //добавляем актуальную дату создания маршрута
            db.Routes.Add(route);
            db.SaveChanges();

            foreach (int item in localId)
            {
                Locality local = db.Localities.Where(l => l.Id == item).First(); //находим объект с айди item
                //route.Locality.Add(local);  // связываем таблицу маршруты с таблицей точек, то есть указываем какие точки принадлежат данному маршруту
                db.SaveChanges();
            }

            return View();
        }
    }
}
