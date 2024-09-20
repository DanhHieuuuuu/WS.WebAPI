using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WS.Constant.Database;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.ApplicationService.OrderManagerModule.Implements;
using WS.Order.Infrastructure;

namespace WS.Order.ApplicationService.Startup
{
    public static class OrderStartup
    {
        public static void ConfigureOrder(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<OrderDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Order
                            );
                        }
                    );
                }
            );
            builder.Services.AddScoped<IOrderService, OrderService>();
        }
    }
}
