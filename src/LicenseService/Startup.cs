using LicenseService.Hubs;
using LicenseService.Interfaces;
using LicenseService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SM.Serialization;

namespace LicenseService {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();

            // Part of the standard configuration
            services.AddSignalR();

            // Map the interfaces to the concrete objects.

            //services.AddSingleton<ILicenseHub, LicenseHub>();
            services.AddSingleton<ILicenses>(new LicenseList(new License()));
            services.AddTransient<ILicense, License>();                                  // Just create a new one each time.
            services.AddTransient<ISerializationUtility, JsonSerializationUtility>((service) => new JsonSerializationUtility(new JsonSerializerSettings()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                // Part of the standard configuration
                endpoints.MapHub<LicenseHub>("/licenseHub");
            });
        }
    }
}
