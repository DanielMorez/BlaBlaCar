using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.ViewModels.Route
{
    public class ShowAllRouteViewModel
    {
        /// <summary>
        /// Автор поста
        /// </summary>
        [Required]
        [Display(Name = "Водитель")]
        public string Driver { get; set; }

        /// <summary>
        /// Дата поста
        /// </summary>
        [Required]
        [Display(Name = "Дата выезда")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Заголовок поста
        /// </summary>
        [Required]
        [Display(Name = "Машина")]
        public string Car { get; set; }

    }
}