using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using CMSAPI.Data;
using CMSAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data;
using CMSAPI.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace CMSAPI
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
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSession();
            services.AddEntityFrameworkSqlServer();
            services.AddScoped<ICMSRepository, CMSRepository>();
            services.AddDbContext<CMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            //services.AddIdentity<Person, IdentityRole>()
                //.AddEntityFrameworkStores<CMSContext>()
                //.AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CMSContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}
