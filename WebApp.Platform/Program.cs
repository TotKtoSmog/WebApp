using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApp.Platform.Areas.Admin.Services;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Models;
using WebApp.Platform.Services;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var env = builder.Environment;
            if (env.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtSettings = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Cookies.ContainsKey("jwt_token"))
                        {
                            context.Token = context.Request.Cookies["jwt_token"];
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<CityHttpClient>();
            builder.Services.AddHttpClient<CityViewHttpClient>();
            builder.Services.AddHttpClient<LocationViewHttpClient>();
            builder.Services.AddHttpClient<LocationGalleryHttpClient>();
            builder.Services.AddHttpClient<FeedbackViewHttpClient>();
            builder.Services.AddHttpClient<FeedbackHttpClient>();
            builder.Services.AddHttpClient<UserHttpClient>();
            builder.Services.AddHttpClient<LocationHttpClient>();

            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<IClientIpService, ClientIpService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IAdminCityService, AdminCityService>();
            builder.Services.AddScoped<IAdminLocationService, AdminLocationService>();
            builder.Services.AddScoped<IAdminFeedbackService, AdminFeedbackService>();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
