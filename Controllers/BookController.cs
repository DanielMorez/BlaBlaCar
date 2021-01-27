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

            var bookRoutes = new List<BookRoute>();

            foreach (BookRoute bookRoute in _routeDbContext.BookRoutes)
            {   
                if (user.Employee.Id == bookRoute.Passenger.Id)
                {
                    bookRoutes.Add(bookRoute);
                }
            }
            
            return View(bookRoutes);
        }

       
    }
}
