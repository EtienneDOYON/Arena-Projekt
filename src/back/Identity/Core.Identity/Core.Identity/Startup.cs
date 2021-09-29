using Core.Data;
using Core.Identity.Data;
using Core.Identity.Data.Repository;
using Core.Identity.Models.Models;
using Core.Services.Classes;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace Core.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private IUnityContainer _container;

        private readonly string AllowAll = "_AllowAll";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _container = new UnityContainer();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ApplicationDbContext context = new ApplicationDbContext();
            context.setDbConnectionString(Configuration.GetConnectionString("DefaultConnection"));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // SignIn settings.
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUnityContainer, UnityContainer>();
            InjectDependencies(services, _container);

            services.AddRazorPages();
            services.AddLogging();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAll,
                                    builder =>
                                    {
                                        builder.AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader();
                                    });
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(AllowAll);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }

        private void InjectDependencies(IServiceCollection services, IUnityContainer container)
        {
            RegisterType<IApplicationUserRepository, ApplicationUserRepository>(services, container);

            RegisterType<IApplicationUserService, ApplicationUserService>(services, container);
        }

        private void RegisterType<T1, T2>(IServiceCollection services, IUnityContainer container)
            where T1 : class
            where T2 : class, T1
        {
            container.RegisterType<T1, T2>();
            services.AddScoped<T1, T2>();
        }
    }
}
