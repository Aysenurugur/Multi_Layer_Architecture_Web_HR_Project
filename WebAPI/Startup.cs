using Core.Models;
using Core.Settings;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Identity Configuration 

            services.Configure<IdentityOptions>(
                options =>
                {
                    options.User.RequireUniqueEmail = true;

                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                });

            services.ConfigureApplicationCookie(
                options =>
                {
                    options.AccessDeniedPath = ""; // sonra eklenecek 
                    options.Cookie.Name = "AspNetCore.Identity.Application";
                    //options.Cookie.HttpOnly = false; // client-side tarafýndan cookie'ye eriþimi engelleme
                    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS üzerinden cookieyi eriþebilir yapma
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.LoginPath = ""; // sonra eklenecek
                    options.SlidingExpiration = true;
                });
            //services.AddIdentity<User, Role>(options=>options.SignIn.RequireConfirmedEmail=true).AddEntityFrameworkStores(/*DbContext*/).AddPasswordValidator<CustomPasswordPolicy>().AddUserValidator<CustomEmailPolicy>(); 

            #endregion

            services.Configure<Admin>(Configuration.GetSection("Admin"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddDbContext<ProjectIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
