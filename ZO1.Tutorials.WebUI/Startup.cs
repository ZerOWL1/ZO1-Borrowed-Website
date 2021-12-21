using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.WebUI.Configs.Autofac;

namespace ZO1.Tutorials.WebUI
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
            //Configs DI Connection String
            services.AddDbContext<BorrowedContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BorrowedConnection")));

            services.AddControllersWithViews();

            //Configs AutoFac
            services.AddOptions();

            //Configs AutoMapper
            services.AddAutoMapper(typeof(Startup)); 
        }

        // This method gets called by the runtime. Use this method to config AutoFac DI.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacConfig());
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

            //All this methods here are middleware
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "blog",
                    pattern: "blog/{*article}",
                    defaults: new { controller = "Blog", action = "Article" });
            });
        }
    }
}
