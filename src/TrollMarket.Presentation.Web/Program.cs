using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Design;
using TrollMarket.DataAccess;
using TrollMarket.Presentation.Web.Configurations;
using TrollMarket.Presentation.Web.Services;
using TrollMarket.Presentation.Web.APIServices;

namespace TrollMarket.Presentation.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddConsole();
            IServiceCollection services = builder.Services;

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "AuthenticationTicket";
                options.LoginPath = "/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = "/Auth/Accessdenied";
            });
            services.AddScoped<AuthService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<MerchandiseService>();
            services.AddScoped<APIShipperService>();
            services.AddScoped<ShipperService>();
            services.AddScoped<ShopService>(); 
            services.AddScoped<CartService>(); 
            services.AddScoped<HistoryService>(); 
            services.AddScoped<AdminService>(); 
            services.AddScoped<APICartService>(); 
            services.AddScoped<APIBalanceService>(); 
            services.AddScoped<APIMerchandiseService>(); 
            services.AddBussinessServices();
            Dependencies.AddDataAccessServices(services, builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Log}/{id?}");

            app.Run();
        }
    }
}