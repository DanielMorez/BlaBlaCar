using BlaBlaCar.Domain.DB;
using BlaBlaCar.Models;
using BlaBlaCar.ViewModels.Route;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RouteDbContext _routeDbContext;

        public HomeController(ILogger<HomeController> logger, RouteDbContext routeDbContext)
        {
            _logger = logger;
            _routeDbContext = routeDbContext ?? throw new ArgumentNullException(nameof(RouteDbContext));
        }

        public IActionResult Index()
        {
            // создаем контекст данных
            var routes = _routeDbContext.Routes
                .Select(x => new ShowAllRouteViewModel
                {
                    Driver = x.Driver.FullName,
                    Date = x.Date,
                    Car = x.Car
                }).OrderByDescending(x => x.Date);
            return View(routes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
