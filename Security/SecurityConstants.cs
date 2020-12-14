using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Security
{
    /// <summary>
    /// Константы, используемые в подсистеме безопасности
    /// </summary>
    public static class SecurityConstants
    {
        /// <summary>
        /// Администратор
        /// </summary>
        public const string AdminRole = "Admin";

        /// <summary>
        /// Пользователь
        /// </summary>
        public const string CustomerRole = "CUSTOMER";

        /// <summary>
        /// Логин Администратора
        /// </summary>
        public const string AdminUserName = "ADMIN";

        /// <summary>
        /// Пароль администратора
        /// </summary>
        public const string AdminPassword = "123456";

        /// <summary>
        /// Email администратора
        /// </summary>
        public const string AdminEmail = "admin@test.ru";

        /// <summary>
        /// Имя администратора
        /// </summary>
        public const string AdminFirstName = "Администратор";

        /// <summary>
        /// Фамилия администратора
        /// </summary>
        public const string AdminSurName = "Системы";

        public static string СustomerRole { get; internal set; }
    }
}
