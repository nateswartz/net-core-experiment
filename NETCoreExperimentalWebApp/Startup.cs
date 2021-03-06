﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NETCoreExperimentalWebApp.Data;
using NETCoreExperimentalWebApp.Models;
using Microsoft.AspNetCore.Identity;
using NETCoreExperimentalWebApp.Infrastructure;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace NETCoreExperimentalWebApp
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
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });

            services.AddDbContext<WebAppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<WebAppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IBookDataProvider, EfBookDataProvider>();
            services.AddSingleton<IStarWarsDataProvider, APIStarWarsProvider>();
            services.AddSingleton<INewsProvider, APINewsProvider>();
            services.AddSingleton<ICryptoTickerProvider, APICryptoTickerProvider>();
            services.AddTransient<IHttpClientAccessor, DefaultHttpClientAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
                HotModuleReplacement = true
            });
            app.UseBrowserLink();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
