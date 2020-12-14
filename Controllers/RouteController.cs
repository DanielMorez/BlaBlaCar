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
using BlaBlaCar.ViewModels.Route;

namespace BlaBlaCar.Controllers
{
    /// <summary>
    /// Контроллер для работы с блогом
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
        /// Возвращение представления Blog возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        /*public IActionResult Index()
        {
            var posts = _routeDbContext.Routes
                .Select(x => new ShowAllRouteViewModel
                {
                    Author = x.Owner.FullName,
                    Date = x.Created,
                    Data = x.Data,
                    Title = x.Title
                }).OrderByDescending(x => x.Date);

            return View(posts);
        }*/
    }
}
