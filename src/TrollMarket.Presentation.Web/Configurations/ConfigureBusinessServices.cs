using TrollMarket.Business.Interfaces;
using TrollMarket.Business.Repositories;

namespace TrollMarket.Presentation.Web.Configurations
{
    public static class ConfigureBusinessServices
    {
        public static IServiceCollection AddBussinessServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>(); 
            services.AddScoped<IMerchandiseRepository, MerchandiseRepository>(); 
            services.AddScoped<IShipmentRepository,ShipmentRepository>(); 
            services.AddScoped<ICartRepository, CartRepository>(); 
            return services; 
        }
    }
}
