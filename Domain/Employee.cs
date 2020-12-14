using BlaBlaCar.Domain.Common;
using BlaBlaCar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Domain
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Возвращяет полное имя пользователя
        /// </summary>
        public string FullName
        {
            get => FirstName + " " + Surname;
        }
    }
}
