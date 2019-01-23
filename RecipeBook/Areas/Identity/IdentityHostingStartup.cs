using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Api.Areas.Identity.Data;

[assembly: HostingStartup(typeof(RecipeBook.Api.Areas.Identity.IdentityHostingStartup))]
namespace RecipeBook.Api.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RecipeBookApiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RecipeBookApiContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<RecipeBookApiContext>();
            });
        }
    }
}