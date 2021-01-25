using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlaBlaCar.Domain.DB;
using BlaBlaCar.Domain;
using BlaBlaCar.Security.Extensions;
using BlaBlaCar.ViewModels.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlaBlaCar.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BlaBlaCar.Controllers
{
    /// <summary>
    /// Контроллер для работы с Маршрутами
    /// </summary> 
    public class RouteController : Controller
    {
        private readonly RouteDbContext _routeDbContext;

        public RouteController(RouteDbContext routeDbContext)
        {
            _routeDbContext = routeDbContext ?? throw new ArgumentNullException(nameof(routeDbContext));
        }


        /// <summary>
        /// Метод открывает страницу с добавлением поста
        /// </summary>
        /// <returns>Возварщает страницу для добавления поста</returns>
        [HttpGet]
        public IActionResult AddRoute()
        {
            return View();
        }

        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Переход на страницу постов пользователя</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRoute(NewRouteViewModels model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            Console.WriteLine(model);

            var post = new Route
            {
                Driver = user.Employee,
                Car = model.Car,
                ToCity = model.ToCity,
                FromCity = model.FromCity,
                Price = model.Price,
                Date = model.Date,
                PassengersAmount = model.PassengersAmount
            };

            _routeDbContext.Routes.Add(post);

            _routeDbContext.SaveChanges();

            return View();

        }

        /// <summary>
        /// Возвращение представления Route возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            // создаем контекст данных
            var routes = _routeDbContext.Routes
                .Select(x => new ShowAllRouteViewModel
                {
                    Driver = x.Driver.FullName,
                    Date = x.Date,
                    Car = x.Car,
                    Price = x.Price,
                    FromCity = x.FromCity,
                    ToCity = x.ToCity,
                    PassengersAmount = x.PassengersAmount
                }).OrderByDescending(x => x.Date);
            return View(routes);
        }

        /// <summary>
        /// Поиск маршрута
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Переход на страницк поиска/returns>
        [HttpPost]
        public IActionResult Search(SearchRouteViewModel model) {


            if (model.PassengersAmount == 0)
            {
                return Redirect("/Home/Index");
            } 

            if (!ModelState.IsValid)
                return View(model);


            var routes = from m in _routeDbContext.Routes
                .Select(x => new ShowAllRouteViewModel
                {
                    Id = x.Id,
                    Driver = x.Driver.FullName,
                    Date = x.Date,
                    Car = x.Car,
                    Price = x.Price,
                    FromCity = x.FromCity,
                    ToCity = x.ToCity,
                    PassengersAmount = x.PassengersAmount
                }).OrderByDescending(x => x.Date)
                         select m;



            routes = routes.Where(
                    s => s.ToCity.Contains(model.ToCity) && 
                         s.FromCity.Contains(model.FromCity) && 
                         s.Date >= model.Date &&
                         s.PassengersAmount >= model.PassengersAmount);


            foreach (ShowAllRouteViewModel r in routes) {
                Console.WriteLine(r);
            }


            return View(routes);
        }

        /// <summary>
        /// Создание брони
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Переход на страницу постов пользователя</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookRoute(long RouteId)
        {   
            var user = this.GetAuthorizedUser();
            Console.WriteLine("--------ROUTE ID---");
            Console.WriteLine(RouteId);
            Console.WriteLine("-------------------");
            /*Route route = _routeDbContext.Routes
                    .Where(
                        b => b.Id == RouteId
                    )
                    .FirstOrDefault();*/
            Route route = null;
            foreach (Route r in _routeDbContext.Routes) {
                Console.WriteLine(r.Id);
                if (r.Id == RouteId+1) {
                    route = r;
                }
            }
            
            Console.WriteLine(user.Employee);

            var book = new BookRoute {
                Passenger = user.Employee,
                Route = route
            };

            _routeDbContext.BookRoutes.Add(book);

            _routeDbContext.SaveChanges();


            Console.WriteLine(book.Route.ToCity);

            return View(book);

        }

        /// <summary>
        /// Метод открывает страницу с добавлением поста
        /// </summary>
        /// <returns>Возварщает страницу для добавления поста</returns>
        [HttpGet]
        public IActionResult GetUserBook()
        {
            /*var routes = _routeDbContext.BookRoutes.Where(

                );*/
            return View();
        }
    }
}
