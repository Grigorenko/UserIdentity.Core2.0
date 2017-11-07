using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Barber.Data.Entities;

namespace Barber
{
  public class Startup
  {
    private IConfigurationRoot configuration;

    public Startup(IHostingEnvironment hostingEnvironment)
    {
      IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(hostingEnvironment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

      this.configuration = configurationBuilder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<Storage>(
        options => options.UseSqlite(this.configuration.GetConnectionString("DefaultConnection"))
      );

      services.AddAuthentication("MyCookieAuthenticationScheme")
        .AddCookie("MyCookieAuthenticationScheme", o =>
        {
          o.LoginPath = "/Home/Login";
          o.AccessDeniedPath = "/Home/Error";
        });

      services.AddScoped<IUserManager, UserManager>();
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole();
      loggerFactory.AddDebug();

      if (hostingEnvironment.IsDevelopment())
      {
        applicationBuilder.UseDeveloperExceptionPage();
        applicationBuilder.UseDatabaseErrorPage();
        applicationBuilder.UseBrowserLink();
      }

      applicationBuilder.UseAuthentication();

      applicationBuilder.UseStaticFiles();
      applicationBuilder.UseMvcWithDefaultRoute();
    }
  }
}
