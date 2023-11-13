using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Dashboard.Clients.Models;
using Dashboard.Hosts.Api;
using Dashboard.Hosts.Api.Controllers;
using Dashboard.Contracts.Post;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dashboard.Infrastructure.ComponentRegistrar;
using Dashboard.Application.AppServices.Contexts.Post.Repositories;
using Dashboard.Application.AppServices.Contexts.Post.Services;
using Dashboard.Infrastructure.DataAccess.Contexts.Post.Repositories;

namespace Dashboard.Clients;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllers(); //+

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(
        s =>
        {
            var includeDocsTypesMarkers = new[]
            {
        typeof(PostDto),
        typeof(PostController),
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
        // + Строка соединения
        //string connection = builder.Configuration.GetConnectionString("DefaultConnection");
        //string connection = "Server=(localdb)\\mssqllocaldb;Database=applicationdb2;Trusted_Connection=True;";

        // + добавляем контекст ApplicationContext в качестве сервиса в приложение
        // builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

        //builder.Services.AddScoped<Service>(sp => new Service(sp.GetRequiredService<IOptions<ApiConfiguration>>().Value));

        builder.Services.ConfigureRepositories(builder.Configuration);

        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            //pattern: "{controller=Home}/{action=Users}"); // для тестов API
            pattern: "{controller=Home}/{action=Index}");

        // вынес в контроллер
        //app.MapControllerRoute(name: "id_get", pattern: "{controller=api}/{action=users}/{id?:int}");

        app.Run();
    }
}

//public class AppContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
//{
//    public ApplicationContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
//        //optionsBuilder.UseSqlite("Data Source=blog.db");

//        return new ApplicationContext(optionsBuilder.Options);
//    }
//}

/*public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    //public string img = "";
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            // данные взяты случайные и ценности не несут
                new User { Id = 1, Name = "Аня", Birthday = Convert.ToDateTime("2005-08-04"), Type = true , DayOfYear = Convert.ToDateTime("2005-08-04").DayOfYear },
                new User { Id = 2, Name = "Светлана Ивановна", Birthday = Convert.ToDateTime("1974-12-31"), Type = false, DayOfYear = Convert.ToDateTime("1974-12-31").DayOfYear },
                new User { Id = 3, Name = "дедушка", Birthday = Convert.ToDateTime("1937-01-15"), Type = true, DayOfYear = Convert.ToDateTime("1937-01-15").DayOfYear }
        );
    }
}*/