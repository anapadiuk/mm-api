using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MM.Common.Services;
using MM.Common.Contracts.Interfaces;

namespace MM.Common
{
    public static class CommonMiddlewareExtensions
    {
        public static IApplicationBuilder UseCommon(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddScoped(typeof(IEntityCreator<>), typeof(EntityCreator<>));
            services.AddScoped(typeof(IEntityCreator<,>), typeof(EntityCreator<,>));
            services.AddScoped(typeof(IEntityUpdater<,>), typeof(EntityUpdater<,>));
            services.AddScoped(typeof(IEntityGetter<,>), typeof(EntityGetter<,>));
            services.AddScoped(typeof(IEntityDeleter<>), typeof(EntityDeleter<>));
            services.AddScoped(typeof(IEntityCollectionGetter<,>), typeof(EntityCollectionGetter<,>));
            services.AddScoped(typeof(IEntityCollectionGetter<>), typeof(EntityCollectionGetter<>));
            return services;
        }
    }
}
