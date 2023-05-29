using System;
using Furniture_Shop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Furniture_Shop.Data.Interfaces;
using Furniture_Shop.Data.Mocks;
using Furniture_Shop.Data.Models;
using Furniture_Shop.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Furniture_Shop
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMemoryCache();
            services.AddSession();
            services.AddDbContext<AppDBContent>(options =>
            {
                options.UseSqlServer(_confString.GetConnectionString("DefaultConnection"));
            });
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                opt.SlidingExpiration = true;
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContent>();
            services.AddTransient<IAllFurniture, FurnitureRepository>();
            services.AddTransient<IFurnitureCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller-Home}/{action-Index}/{id?}");
                    
                    routes.MapRoute(
                        name: "categoryFilter",
                        template: "Furnitures/{action}/{category?}",
                        defaults: new { Controller = "Furnitures", action = "List" });
                });
            
            using (var scope = app.ApplicationServices.CreateScope()) {
                AppDBContent content = scope.ServiceProvider.
                    GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
