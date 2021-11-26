using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Kino.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Kino.Data;
using Kino.Services;
using Pomelo;
using Pomelo.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace Kino
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(dbCtxOption => {
                dbCtxOption.UseMySql(
                    Configuration.GetConnectionString("MariaDbConnectionString"),  
                    new MySqlServerVersion(new Version(10, 3, 31))
                ).LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });

            services.AddAuthentication("Cookie")
                .AddCookie("Cookie", options => 
                {
                    options.LoginPath = "/auth/connect"; 
                    options.LogoutPath = "/auth/disconnect"; 
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
                    options.SlidingExpiration = true; 
                    options.Cookie.IsEssential = true;
                });

            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMoviesService, MoviesService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
