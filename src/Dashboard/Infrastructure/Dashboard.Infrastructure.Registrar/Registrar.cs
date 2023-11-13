using Dashboard.Application.AppServices.Contexts.Post.Repositories;
using Dashboard.Infrastructure.DataAccess;
using Dashboard.Infrastructure.DataAccess.Contexts.Post.Repositories;
using Dashboard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Infrastructure.ComponentRegistrar
{
    public static class Registrar
    {
        public static IServiceCollection ConfigureRepositories(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }

        /// <summary>
        /// Добавляет компоненты слоя доступа к данным с помощью EF-Core.
        /// </summary>
        private static IServiceCollection AddDbContext(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ApplicationConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Не найдена строка подключения");
            }

            services.AddDbContext<BaseDbContext>(builder =>
                builder.UseNpgsql(connectionString));

            services.AddScoped((Func<IServiceProvider, DbContext>)(sp =>
                sp.GetRequiredService<BaseDbContext>()));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
