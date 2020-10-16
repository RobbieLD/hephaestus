using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Hephaestus
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://0.0.0.0:5051","http://0.0.0.0:5050");
                }).UseWindowsService();
    }
}
