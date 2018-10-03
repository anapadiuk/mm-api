using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace MM.Orders
{
    public static class OrdersMiddlewareExtensions
    {
        public static IApplicationBuilder UseOrders(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddOrders(this IServiceCollection services)
        {
            services.AddAutoMapper();
            return services;
        }
    }
}
