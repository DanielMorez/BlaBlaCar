using System;

namespace BlaBlaCar.Infrastructure
{
    /// <summary>
    /// Интерфейс для обеспечения гарантии целостности (возможности корректной работы) системы при запуске
    /// Реализации данного интерфейса могут к примеру проверять соответствие схемы бд и модели данных
    /// Или же факт запуска той или иной службы, доступности сервера
    /// </summary>
    internal interface IStartupPreConditionGuarantor
    {
        /// <summary>
        /// Обеспечение возможности запуска 
        /// </summary>
        /// <param name="services">IoC контейнер</param>
        /// <exception cref="StartupPreConditionException">В случае возникновения данного исключения запуск системы невозможен</exception>
        void Ensure(IServiceProvider services);
    }
}
