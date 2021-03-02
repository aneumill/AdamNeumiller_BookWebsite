using AdamNeumiller_BookWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                   options.UseSqlServer(Configuration["ConnectionStrings:BookConnection"].Replace("|DataDirectory|", path));
               });

            services.AddScoped<iBookRepository, EFBookRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Building an enpoint
            endpoints.MapControllerRoute("catpage",
                "{category}/{page:int}",
                new { Controller = "Home", action = "Index" }
                );

                //Another endpoint i.e. just the page number
                endpoints.MapControllerRoute("page", 
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                //Another endpoint
                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

             //Endpoint for P and number 
            endpoints.MapControllerRoute(
                //Customize the URL Mapping to work for /P
                "pagination",
                "Books/P{page}",
                new { Controller = "Home", action = "Index" });

                  endpoints.MapControllerRoute(
                //Customize the URL Mapping to work for /P
                "pagination",
                "P{page}",
                new { Controller = "Home", action = "Index" });


                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
