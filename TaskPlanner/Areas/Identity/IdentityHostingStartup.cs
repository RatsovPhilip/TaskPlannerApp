using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TaskPlanner.Areas.Identity.IdentityHostingStartup))]
namespace TaskPlanner.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}