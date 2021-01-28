using Lesson4Project.Configurations;
using Lesson4Project.Models;
using Lesson4Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InfestationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("InfestationDbConnectionNew")));
            
            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddScoped<IHumanRepository, HumanRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            
            services.AddMemoryCache();
            services.AddHostedService<LoadFileHostedService>();
            services.AddScoped<IRestApiExampleClient, RestApiExampleClient>();
            services.AddScoped<IFileService, FileService>();


            services.AddScoped<ServiceFactory>();
            services.AddIdentity<CustomUser,IdentityRole>().AddEntityFrameworkStores<InfestationDbContext>();
            services.Configure<IdentityOptions>(options=>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
            });
            services.Configure<InfestationEmailConfiguration>(_configuration.GetSection("Infestation:Email"));
            services.Configure<InfestationSmsConfiguration>(_configuration.GetSection("Infestation:Twilio"));
            services.Configure<InfestationCacheConfiguration>(_configuration.GetSection("CacheParams"));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
               // app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseMiddleware<WriteToConsoleMiddleWare>("Hello");
            //app.UseWriteToConsole("Hello");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
