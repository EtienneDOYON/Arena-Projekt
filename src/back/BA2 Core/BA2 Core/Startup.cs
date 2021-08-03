using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unity;
using Core.Unity.Config;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Core.Data.Repository.Interfaces;
using Core.Data.Repository.Classes;
using Core.Services.Services.Classes;
using Core.Services.Services.Interfaces;
using Unity.Injection;
using Wave.Data.Ef6;
using Wave.Data.Repositories;
using Core.Data.Entities;
using Core.Data.HelperModels;
using Core.Data.UnitOfWork;

namespace BA2_Core
{
    public class Startup
    {
        private IUnityContainer _container;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _container = new UnityContainer();

            services.AddControllersWithViews();
            services.AddSession();
            services.AddScoped<IUnityContainer, UnityContainer>();

            services.AddMemoryCache();

            services.AddDbContext<CoreContext>(option => option.UseSqlServer(_configuration.GetConnectionString("BA2_db")));

            RegisterInjection(services, _container);
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddRazorPages();

            services.RegisterAutoMapperConfiguration(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }

        private void RegisterInjection(IServiceCollection services, IUnityContainer container)
        {
            RegisterRepository<IUserRepository, UserRepository>(services, container);

            RegisterService<IUserService, UserService>(services, container);
        }

        private void RegisterRepository<T1, T2>(IServiceCollection services, IUnityContainer container)
            where T1 : class
            where T2 : class, T1
        {
            container.RegisterType<T1, T2>();
            services.AddScoped<T1, T2>();
        }


        private void RegisterService<T1, T2>(IServiceCollection services, IUnityContainer container)
            where T1 : class
            where T2 : class, T1
        {
            container.RegisterType<T1, T2>();
            services.AddScoped<T1, T2>();
        }
    }
}
