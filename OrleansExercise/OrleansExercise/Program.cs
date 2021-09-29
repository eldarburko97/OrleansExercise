using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace OrleansExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args: args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args: args)
                .ConfigureWebHostDefaults(configure: webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseOrleans(configureDelegate: builder =>
                {
                    builder.Configure<ClusterOptions>(configureOptions: options =>
                    {
                        options.ClusterId = "my-first-cluster";
                        options.ServiceId = "AspNetSampleApp";
                    });
                    builder.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000);
                    builder.UseAzureStorageClustering(configureOptions: options => { options.ConnectionString = "UseDevelopmentStorage=true"; });

                    builder.UseDashboard();
                });
        }
    }
}