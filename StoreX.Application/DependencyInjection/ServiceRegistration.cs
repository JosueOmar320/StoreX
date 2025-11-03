using Microsoft.Extensions.DependencyInjection;
using StoreX.Application.Interfaces;
using StoreX.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Agrega aquí los servicios generales o específicos
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IMovementLineService, MovementLineService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IProductSupplierService, ProductSupplierService>();
            services.AddScoped<ICashMovementService, CashMovementService>();
            services.AddScoped<ICashSessionService, CashSessionService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderLineService, OrderLineService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IProductPriceService, ProductPriceService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IPurchaseOrderLineService, PurchaseOrderLineService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            return services;
        }
    }
}
