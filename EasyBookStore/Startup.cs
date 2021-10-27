using System;
using EasyBookStore.Dal.Context;
using EasyBookStore.Data;
using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.Infrastructure.Middleware;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services;
using EasyBookStore.Services.Cookies;
using EasyBookStore.Services.Database;
using EasyBookStore.Services.Memory;
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
            services.AddDbContext<BookStoreContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")/*, o => o.EnableRetryOnFailure()*/));

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

            services.AddScoped<ICartStore, CookiesCartStore>();
            services.AddScoped<ICartService, CartService>();

            services.AddSingleton<IWorkerData, InMemoryWorkerData>();
            //services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, DatabaseProductData>();

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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
