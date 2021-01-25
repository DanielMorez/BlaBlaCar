using BlaBlaCar.Domain;
using BlaBlaCar.Domain.DB;
using BlaBlaCar.Security.Extensions;
using BlaBlaCar.ViewModels.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Controllers
{
    public class BookController : Controller
    {
        private readonly RouteDbContext _routeDbContext;

        public BookController(RouteDbContext routeDbContext)
        {
            _routeDbContext = routeDbContext ?? throw new ArgumentNullException(nameof(routeDbContext));
        }
        public IActionResult Index()
        {
            return View();
        }

        /*/// <summary>
        /// Создание брони
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Переход на страницу постов пользователя</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookRoute(BookRouteViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            Console.WriteLine(model);

            *//*var post = new Route
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

            _routeDbContext.SaveChanges();*//*

            return View();

        }*/
    }
}
