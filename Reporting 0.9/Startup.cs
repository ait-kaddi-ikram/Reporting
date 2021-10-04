using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Ninject.Activation;
using Reporting.Models;
using System;

namespace Reporting
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<ReportingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddControllersWithViews();
            services.AddIdentity<AppUser, IdentityRole>(
                options => {
                    options.Password.RequiredLength = 7;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                }).AddEntityFrameworkStores<AppDbContext>();
            services.AddMvc(
             options =>
             {
                 options.EnableEndpointRouting = false;
                 var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                 options.Filters.Add(new AuthorizeFilter(policy));
                

             }

         ).AddXmlSerializerFormatters();


            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthSection = Configuration.GetSection("Authentication:google");
                    options.ClientId = googleAuthSection["ClientId"];
                    options.ClientSecret = googleAuthSection["ClientSecret"];

                });
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");
       
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
