using System;

namespace BlaBlaCar.Infrastructure
{
    /// <summary>
    /// Исключение, вызванное неправилньой средой запуска приложения
    /// Дальнешее выполнение невозможно
    /// </summary>
    public class StartupPreConditionException : Exception
    {
        /// <summary>
        /// Создание экземпляра класса <seealso cref="StartupPreConditionException"/>
        /// </summary>
        /// <param name="message">Сообщение</param>
        public StartupPreConditionException(string message) : base(message)
        {

        }
    }
}
