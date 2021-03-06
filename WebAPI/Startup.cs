using Core.AbstractUnitOfWork;
using Data.UnitOfWork;
using Core.Entities.Identity;
using Core.Models;
using Core.Settings;
using Data.Context;
using Data.CustomPolicies;
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
using WebAPI.Mapping;
using Services.Services;
using Core.Services;

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

            services.ConfigureApplicationCookie(
                options =>
                {
                    options.AccessDeniedPath = ""; // sonra eklenecek MVC controller ve action
                    options.Cookie.Name = "AspNetCore.Identity.Application";
                    //options.Cookie.HttpOnly = false; // client-side taraf?ndan cookie'ye eri?imi engelleme
                    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS ?zerinden cookieyi eri?ebilir yapma
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.LoginPath = ""; // sonra eklenecek login mvc controller action
                    options.SlidingExpiration = true;
                });

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<ProjectIdentityDbContext>()
                .AddPasswordValidator<CustomPasswordPolicy>()
                .AddUserValidator<CustomEmailPhonePolicy>();

            #endregion

            services.Configure<Admin>(Configuration.GetSection("Admin"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddDbContext<ProjectIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));

            services.AddAutoMapper(typeof(Startup));

            #region AddScoped Methods

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBreakService, BreakService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDayOffService, DayOffService>();
            services.AddScoped<IDayOffTypeService, DayOffTypeService>();
            services.AddScoped<IDebitService, DebitService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileTypeService, FileTypeService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVetoMessageService, VetoMessageService>();

            #endregion

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                        //builder.WithOrigins("https://hrwebapi.azurewebsites.net/");
                        builder.AllowAnyOrigin();
                    });
            }); 
            #endregion
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

            app.UseStaticFiles();

            app.UseCors("MyCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
