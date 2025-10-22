using Microsoft.Extensions.DependencyInjection;
using StoreX.Domain.Interfaces;
using StoreX.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Repositorios
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderLineRepository, PurchaseOrderLineRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            // Servicios externos o técnicos si tienes
            // services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
