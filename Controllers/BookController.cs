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
            var user = this.GetAuthorizedUser();

            var routes = from m in _routeDbContext.Routes
                .Select(x => new ShowAllRouteViewModel
                {
                    Id = x.Id,
                    Driver = x.Driver,
                    Date = x.Date,
                    Car = x.Car,
                    Price = x.Price,
                    FromCity = x.FromCity,
                    ToCity = x.ToCity,
                    PassengersAmount = x.PassengersAmount
                }).OrderByDescending(x => x.Date)
                         select m;

            var routeIds = new List<long>();
            foreach (var book in _routeDbContext.BookRoutes)
            {
                if (book.Passenger != null)
                {
                    routeIds.Add(book.RouteId);
                }
            }
            routes = routes.Where(s => routeIds.Contains(s.Id));

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
        public IActionResult RemoveBook(long RouteId)
        {
            var user = this.GetAuthorizedUser();

            BookRoute book = null;
            foreach (var post in _routeDbContext.BookRoutes)
            {
                var u = post.Passenger;
                var id = post.RouteId;
                if ((u != null) && (id == RouteId))
                {
                    book = post;
                }
            }

            _routeDbContext.BookRoutes.Remove(book);

            _routeDbContext.SaveChanges();

            return RedirectToAction("Index", "Book");

        }

    }
}
