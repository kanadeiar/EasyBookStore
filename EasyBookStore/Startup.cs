using System;
using EasyBookStore.Dal.Context;
using EasyBookStore.Data;
using EasyBookStore.Domain.Models;
using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.Infrastructure.Middleware;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services;
using EasyBookStore.Services.Cookies;
using EasyBookStore.Services.Database;
using EasyBookStore.WebModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyBookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseType = Configuration["Database"];

            switch (databaseType)
            {
                case "SqlServer":
                    services.AddDbContext<BookStoreContext>(opt =>
                    opt.UseSqlite(Configuration.GetConnectionString(databaseType)));
                    break;
                case "Sqlite":
                    services.AddDbContext<BookStoreContext>(opt =>
                    opt.UseSqlite(Configuration.GetConnectionString(databaseType),
                    o => o.MigrationsAssembly("EasyBookStore.Dal.Sqlite")));
                    break;
                default: throw new InvalidOperationException($"Тип БД {databaseType} не поддерживается");
            }

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<BookStoreContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(o =>
            {
#if true
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 3;
                o.Password.RequiredUniqueChars = 3;
#endif
                o.User.RequireUniqueEmail = false;
                o.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";

                o.Lockout.AllowedForNewUsers = false;
                o.Lockout.MaxFailedAccessAttempts = 10;
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            });

            services.ConfigureApplicationCookie(o =>
            {
                o.Cookie.Name = "EasyBookStore";
                //o.Cookie.HttpOnly = true;
                o.ExpireTimeSpan = TimeSpan.FromDays(10);
                o.LoginPath = "/Account/Login";
                o.LogoutPath = "/Account/Logout";
                o.AccessDeniedPath = "/Account/AccessDenied";
                o.SlidingExpiration = true;
            });

            services.AddTransient<EasyBookStoreDbInitializer>();

            services.AddScoped<IMapper<ProductWebModel>, WebMapperService>();
            services.AddScoped<IMapper<WorkerDetailsWebModel>, WebMapperService>();
            services.AddScoped<IMapper<WorkerEditWebModel>, WebMapperService>();
            services.AddScoped<IMapper<Worker>, WebMapperService>();
            services.AddScoped<IMapper<ProductEditWebModel>, WebMapperService>();
            services.AddScoped<IMapper<Product>, WebMapperService>();

            services.AddTransient<WebMapperService>();

            services.AddScoped<ICartStore, CookiesCartStore>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, DatabaseOrderData>();

            services.AddScoped<IProductData, DatabaseProductData>();
            services.AddScoped<IWorkerData, DatabaseWorkerData>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStatusCodePagesWithRedirects("~/home/error/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<DebugMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
