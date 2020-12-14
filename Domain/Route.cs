using BlaBlaCar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Domain
{
    /// <summary>
    /// Маршрут
    /// </summary>
    public class Route : Entity
    {
        // Водителя, создавший маршрут
        public Employee Driver { get; set; }
        // Название автомобиля
        public string Car { get; set; }
        // название города из которого он едет
        public string FromCity { get; set; }
        // название города в который он едет
        public string ToCity { get; set; }
        // цена 
        public int Price { get; set; }
        // дата выезда
        public DateTime Date { get; set; }
        // кол-во возможных пассажиров
        public int PassengersAmount { get; set; }
    }
}
