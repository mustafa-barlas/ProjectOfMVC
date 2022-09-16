using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MvcProjeKampii
{
    public class Program
    {
      //  GlobalFilters.Filters.Add(new AuthorizeAttribute());
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
