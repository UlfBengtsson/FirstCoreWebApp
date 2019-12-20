using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstCoreWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();// add MVC so we can use it
            //services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseDefaultFiles();  //looks for index.html or default.html in wwwroot folder.
            app.UseStaticFiles();   //default opens up the wwwroot folder to be accessed.

            app.UseSession();
            //app.UseHttpContextItemsMiddleware();// Core 3 update meesed this one up

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Custom Routes
                endpoints.MapControllerRoute(
                    name: "ReviewRoute",                                        //Name of Route rule
                    pattern: "TheReviews",                                      //Url to match
                    defaults: new { controller = "Reviews", action = "Index" }  //What Controller & Action to call
                    );

                endpoints.MapControllerRoute(
                    name: "CreateReviewRoute",                                        //Name of Route rule
                    pattern: "WriteYourReview",                                      //Url to match
                    defaults: new { controller = "Reviews", action = "Create" }  //What Controller & Action to call
                    );

                // special routes before default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
