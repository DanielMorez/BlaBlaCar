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
        // бронирования
        public int Id { get; set; }
        // ID пассажира
        public Employee Passenger { get; set; }
        // ID маршрута
        public Route Route { get; set; }

    }
}
