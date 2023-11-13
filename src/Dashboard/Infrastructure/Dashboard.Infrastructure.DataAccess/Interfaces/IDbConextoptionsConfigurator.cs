using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Interfaces
{
    /// <summary>
    /// Конфигуратор контекста.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IDbConextoptionsConfigurator<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Выполняет конфигурацию контекста.
        /// </summary>
        /// <param name="options">Настройки.</param>
        void Configure(DbContextOptionsBuilder<TContext> options);
    }
}