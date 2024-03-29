using AdamNeumiller_BookWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Hilton added this part--> Jumpstarts the process
            services.AddDbContext<BookDBcontext>(options =>
               {
                   string path = Directory.GetCurrentDirectory();
                   //Solution to properly save the database to the proeject file. Puts the current project file directory into the connection string
                   options.UseMySql(Configuration["ConnectionStrings:BookConnection"].Replace("|DataDirectory|", path));
                       
                       //.Replace("|DataDirectory|", path));

               });

            services.AddScoped<iBookRepository, EFBookRepository>();
            services.AddRazorPages();
            //Set up the session
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
            //Build for the session 
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Building an enpoint
            endpoints.MapControllerRoute("catpage",
                "{category}/{pageNum:int}",
                new { Controller = "Home", action = "Index" }
                );

                //Another endpoint i.e. just the page number
                endpoints.MapControllerRoute("pageNum", 
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //Another endpoint
                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

             //Endpoint for P and number 
            endpoints.MapControllerRoute(
                //Customize the URL Mapping to work for /P
                "pagination",
                "Books/P{pageNum}",
                new { Controller = "Home", action = "Index" });

                  endpoints.MapControllerRoute(
                //Customize the URL Mapping to work for /P
                "pagination",
                "P{pageNum}",
                new { Controller = "Home", action = "Index" });


                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
               

            });

            //SeedData.EnsurePopulated(app);
        }
    }
}
