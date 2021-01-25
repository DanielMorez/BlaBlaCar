using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.ViewModels.Route
{
    public class NewRouteViewModels
    {

        /// <summary>
        /// Город выезда
        /// </summary>
        [Required]
        [Display(Name = "Город вызда")]
        public String FromCity { get; set; }

        /// <summary>
        /// Город приезда
        /// </summary>
        [Required]
        [Display(Name = "Город назначения ")]
        public String ToCity { get; set; }

        /// <summary>
        /// Дата выезда
        /// </summary>
        [Required]
        [Display(Name = "Дата выезда")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Цена за пассажира
        /// </summary>
        [Required]
        [Display(Name = "Цена за пассажира")]
        public int Price { get; set; }

        /// <summary>
        /// Машина
        /// </summary>
        [Required]
        [Display(Name = "Машина")]
        public String Car { get; set; }
        /// <summary>
        /// Количесество пассажиров
        /// </summary>
        [Required]
        [Display(Name = "Количество пассажиров")]
        public int PassengersAmount { get; set; }

    }
}

