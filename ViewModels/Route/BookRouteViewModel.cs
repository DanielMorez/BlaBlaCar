using static BlaBlaCar.Domain.Route;
using static BlaBlaCar.Domain.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.ViewModels.Route
{
    public class BookRouteViewModel
    {
        // пассажир
        [Required]
        [Display(Name = "Пользователь")]
        public BlaBlaCar.Domain.Employee Passenger { get; set; }
        // маршрут
        [Required]
        [Display(Name = "Маршрут")]
        public BlaBlaCar.Domain.Route Route { get; set; }
    }
}

