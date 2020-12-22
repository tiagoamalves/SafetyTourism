using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafetyTourism.Areas.Identity.Data;
using SafetyTourism.Data;

[assembly: HostingStartup(typeof(SafetyTourism.Areas.Identity.IdentityHostingStartup))]
namespace SafetyTourism.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SafetyTourism12Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SafetyTourism12ContextConnection")));

                services.AddDefaultIdentity<SafetyTourismUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SafetyTourism12Context>();
            });
        }
    }
}