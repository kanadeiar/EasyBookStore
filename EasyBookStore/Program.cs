using EasyBookStore.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace EasyBookStore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<EasyBookStoreDbInitializer>();
                await initializer/*.RecreateDatabase()*/.InitAsync();
            }

            await host.RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(host => host
                    .UseStartup<Startup>()
                );
    }
}
