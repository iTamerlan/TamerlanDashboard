using Dashboard.Application.AppServices.Contexts.Post.Repositories;
using Dashboard.Application.AppServices.Contexts.Post.Services;
using Dashboard.Contracts.Post;
using Dashboard.Contracts.User;
using Dashboard.Contracts.Comment;
using Dashboard.Hosts.Api;
using Dashboard.Hosts.Api.Controllers;
using Dashboard.Infrastructure.DataAccess.Contexts.Post.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dashboard.Infrastructure.ComponentRegistrar;
using Dashboard.Application.AppServices.Contexts.Comment.Services;
using Dashboard.Application.AppServices.Contexts.Comment.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Comment.Repositories;
using Dashboard.Application.AppServices.Contexts.User.Services;
using Dashboard.Application.AppServices.Contexts.User.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.User.Repositories;
using Dashboard.Application.AppServices.Contexts.Community.Services;
using Dashboard.Application.AppServices.Contexts.Community.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Community.Repositories;
using Dashboard.Application.AppServices.Contexts.Product.Services;
using Dashboard.Application.AppServices.Contexts.Product.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Product.Repositories;
using Dashboard.Application.AppServices.Contexts.Feedback.Services;
using Dashboard.Infrastructure.DataAccess.Contexts.Feedback.Repositories;
using Dashboard.Application.AppServices.Contexts.Feedback.Repositories;
using Dashboard.Application.AppServices.Contexts.Voting.Services;
using Dashboard.Application.AppServices.Contexts.Voting.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Voting.Repositories;
using Dashboard.Application.AppServices.Contexts.Bidding.Services;
using Dashboard.Application.AppServices.Contexts.Bidding.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Bidding.Repositories;
using Dashboard.Application.AppServices.Contexts.Bookmark.Services;
using Dashboard.Application.AppServices.Contexts.Bookmark.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Bookmark.Repositories;
using Dashboard.Application.AppServices.Contexts.History.Services;
using Dashboard.Application.AppServices.Contexts.History.Repositories;
using Dashboard.Application.AppServices.Contexts.Tag.Services;
using Dashboard.Application.AppServices.Contexts.Tag.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Tag.Repositories;
using Dashboard.Application.AppServices.Contexts.Category.Repositories;
using Dashboard.Infrastructure.DataAccess.Contexts.Category.Repositories;
using Dashboard.Application.AppServices.Contexts.Category.Services;
using Dashboard.Infrastructure.DataAccess.Contexts.History.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(
        s =>
        {
            var includeDocsTypesMarkers = new[]
            {
        typeof(PostDto),
        typeof(PostController),

        typeof(CommentDto),
        typeof(CommentController),

        typeof(UserDto),
        typeof(UserController),
            };

            foreach (var marker in includeDocsTypesMarkers)
            {
                var xmlName = $"{marker.Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlName);

                Console.WriteLine(xmlPath);

                if (File.Exists(xmlPath))
                    s.IncludeXmlComments(xmlPath);
            }
        });

        builder.Services.ConfigureRepositories(builder.Configuration);

        builder.Services.AddScoped<IMyDependency, MyDependency>();
        // AddHttpClient ?
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();

        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        // builder.Services.AddScoped<IPostRepository, PostTestRepository>(); // Выставлен тестовый репозиторий!

        builder.Services.AddScoped<ICommunityService, CommunityService>();
        builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IFeedbackService, FeedbackService>();
        builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

        builder.Services.AddScoped<IVotingService, VotingService>();
        builder.Services.AddScoped<IVotingRepository, VotingRepository>();

        builder.Services.AddScoped<IBiddingService, BiddingService>();
        builder.Services.AddScoped<IBiddingRepository, BiddingRepository>();

        builder.Services.AddScoped<IBookmarkService, BookmarkService>();
        builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();

        builder.Services.AddScoped<IHistoryService, HistoryService>();
        builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

        builder.Services.AddScoped<ITagService, TagService>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}