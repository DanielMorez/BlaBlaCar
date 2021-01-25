using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.ViewModels.Route
{
    public class SearchRouteViewModel
    {
        /// <summary>
        /// Дата поста
        /// </summary>
        [Required]
        [Display(Name = "Дата выезда")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Город выезда
        /// </summary>
        [Required]
        [Display(Name = "Город выезда")]
        public string FromCity { get; set; }

        /// <summary>
        /// Город выезда
        /// </summary>
        [Required]
        [Display(Name = "Город приезда")]
        public string ToCity { get; set; }


        /// <summary>
        /// Количество пассажиров
        /// </summary>
        [Required]
        [Display(Name = "Кол-во пассажиров")]
        public int PassengersAmount { get; set; }

    }
}