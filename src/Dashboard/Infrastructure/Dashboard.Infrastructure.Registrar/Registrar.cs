using Dashboard.Application.AppServices.Contexts.Bidding.Repositories;
using Dashboard.Application.AppServices.Contexts.Bookmark.Repositories;
using Dashboard.Application.AppServices.Contexts.Category.Repositories;
using Dashboard.Application.AppServices.Contexts.Comment.Repositories;
using Dashboard.Application.AppServices.Contexts.Community.Repositories;
using Dashboard.Application.AppServices.Contexts.Feedback.Repositories;
using Dashboard.Application.AppServices.Contexts.History.Repositories;
using Dashboard.Application.AppServices.Contexts.Post.Repositories;
using Dashboard.Application.AppServices.Contexts.Product.Repositories;
using Dashboard.Application.AppServices.Contexts.Tag.Repositories;
using Dashboard.Application.AppServices.Contexts.User.Repositories;
using Dashboard.Application.AppServices.Contexts.Voting.Repositories;
using Dashboard.Infrastructure.DataAccess;
using Dashboard.Infrastructure.DataAccess.Contexts.Bidding.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Bookmark.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Category.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Comment.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Community.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Feedback.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.History.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Post.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Product.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Tag.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.User.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Voting.Repositories;
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
            services.AddScoped<IBiddingRepository, BiddingRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVotingRepository, VotingRepository>();
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
