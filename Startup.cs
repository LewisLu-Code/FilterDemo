using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterDemo.Data;
using FilterDemo.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FilterDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        ILogger _logger;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Razor Page Filters
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddFolderApplicationModelConvention("/ProjectItems", model => model.Filters.Add(new SampleAsyncPageFilter(_logger)));
            });
            services.AddMvc(options =>
            {
                //options.Filters.Add(new SampleAsyncPageFilter(_logger));
                options.Filters.Add(new SamplePageFilter(_logger));
            });

            
            services.AddDbContext<ManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //MVC Filters
            services.AddMvc(options =>
            {
                
                options.Filters.Add<AuthorizationFilter>();
                options.Filters.Add<ResourceFilter>();
                options.Filters.Add<Action1Filter>(order:1);
                //options.Filters.Add<ActionsFilter>();
                options.Filters.Add<ExceptionsFilter>();
                options.Filters.Add<ResultFilter>();
               
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "MyArea",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
