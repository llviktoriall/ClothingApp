using ClothingApp.Data;
using ClothingApp.Data.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Text;
using ClothingApp.Core.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClothingApp.Core.Services.WeatherService;
using ClothingApp.Web.Areas.Identity;
using ClothingApp.Data.Common.Entities;
using Microsoft.AspNetCore.Identity;
using ClothingApp.Data.Common.Interfaces;
using ClothingApp.Data.Common.Repositories;

namespace ClothingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWeatherService>(ioc =>
            {
                return new WeatherService(Configuration.GetValue<string>("Token"));
            });

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                      x => x.MigrationsAssembly("ClothingApp.Web")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<DataContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IClothingService, ClothingService>();
            //services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            Seed.Initialize(app.ApplicationServices);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
