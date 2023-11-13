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