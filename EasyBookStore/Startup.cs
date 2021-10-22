using EasyBookStore.Dal;
using EasyBookStore.Data;
using EasyBookStore.Infrastructure.Middleware;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Services.Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddTransient<EasyBookStoreDbInitializer>();

            services.AddSingleton<IWorkerData, InMemoryWorkerData>();
            services.AddSingleton<IProductData, InMemoryProductData>();

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

            app.UseMiddleware<DebugMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
