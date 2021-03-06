using BookStore_App.Data;
using BookStore_App.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();     //For setting up MVC envirnment

            //For Runtime compilation of razor file
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
                
            // Uncomment this code to disable client side validation
            //    .AddViewOptions(option=> {
            //    option.HtmlHelperOptions.ClientValidationEnabled = false;
            //});  
#endif
            // Add Context Information and connection string to application 
            services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer("server=.;Database=BookStore;Integrated Security=True;"));
            // here we give coonection string hardcoded but in real time application we get this from appsettings.json file

            services.AddScoped<BookRepository, BookRepository>();  // Code for dependancy injection Bookrepository

            services.AddScoped<LanguageRepository, LanguageRepository>();  // Code for dependancy injection LanguageRepository
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();  // For Using static Files in application with default content folder.       
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}


// For using static files in application for accessing files from another folder
// app.UseStaticFiles(new StaticFileOptions() 
// {
//     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
//     RequestPath = "/StaticFiles"
// });


// adding middleware to application

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("Hello from First MiddleWare");

//     await next();

//     await context.Response.WriteAsync("Hello from First MiddleWare responce");
// });


//Adding new Route as middleware

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/tejas", async context =>
//    {
//        await context.Response.WriteAsync("Hello Tejas!");
//    });
//});

// For creating default route
//endpoints.MapControllerRoute(
//    name: "default",
//    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");