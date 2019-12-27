using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployManagment.core.DataContext;
using EmployManagment.core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployManagment.core
{
    public class Startup
    {
        private readonly IConfiguration _Config;

        public Startup(IConfiguration _config)
        {
            _Config = _config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(option => option.UseSqlServer(_Config.GetConnectionString("EmployeeDBConnection")));

            services.AddIdentity<IdentityUser,IdentityRole>(option => {
                option.Password.RequiredLength = 10;
                option.Password.RequiredUniqueChars = 3;
                option.Password.RequireNonAlphanumeric = false;

            })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvc((rout) => { rout.MapRoute("default", "{controller=Home}/{action=index}/{id?}"); });
        }
    }
}
