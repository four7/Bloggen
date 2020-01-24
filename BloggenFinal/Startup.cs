using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggenFinal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BloggenFinal
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
            services.AddMvc(setupAction: i => i.EnableEndpointRouting = false);
            var conn = @"Server=localhost;Database=Blogg;Trusted_Connection=True;";
            services.AddDbContext<BloggContext>(options => options.UseSqlServer(conn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "Default",
                template: "{controller=Home}/{action=Index}"
                    );
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
        }
    }
}
