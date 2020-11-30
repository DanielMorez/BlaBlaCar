using BlaBlaCar.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Domain
{
    /// <summary>
    /// Пользователь (водитель и пассажир)
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public Employee Employee { get; set; }
    }
}
