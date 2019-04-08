using System;
using Domain._Base;
using Domain.Context;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Ioc
{
    public static class StartUpIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=event.db"));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IEventRepository), typeof(EventRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<EventStorage>();
        }
    }
}
