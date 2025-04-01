using Microsoft.EntityFrameworkCore;
using WebApp.API.Contexts;
using WebApp.API.Repositories;
using WebApp.API.Repositories.Interface;

namespace WebApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ICityInHomePageViewRepository, CityInHomePageViewRepository>();
            builder.Services.AddScoped<ILocationInCityViewRepository, LocationInCityViewRepository>();
            builder.Services.AddScoped<ILocationInHomePageViewRepository, LocationInHomePageViewRepository>();
            builder.Services.AddScoped<ILocationGalleryRepository, LocationGalleryRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IFeedbackViewRepository, FeedbackViewRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddDbContextFactory<CityContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<CityInHomePageContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<LocationInCityContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<LocationInHomePageContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<LocationGalleryContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<FeedbackContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<FeedbackViewContext>(o => o.UseNpgsql(connectionString));
            builder.Services.AddDbContextFactory<UserContext>(o => o.UseNpgsql(connectionString));
            var app = builder.Build();

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
}
