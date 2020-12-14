using BlaBlaCar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Domain
{
    /// <summary>
    /// Бронирование маршрута
    /// </summary>
    public class BookRoute : Entity
    {
        // пассажир
        public Employee Passenger { get; set; }
        // маршрут
        public Route Route { get; set; }

    }
}
