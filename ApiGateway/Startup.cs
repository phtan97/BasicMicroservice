using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGetway
{
    public class Startup
    {
        private readonly IConfiguration _cfg;
        public Startup(IConfiguration configuration) => _cfg = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var identityUrl = _cfg.GetValue<string>("https://localhost:5002");
            var authenticationProviderKey = "IdentityApiKey";
            //…
            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, x =>
                {
                    x.Authority = "https://localhost:5002";
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                    //x.RequireHttpsMetadata = false;
                    //x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    //{
                    //    ValidAudiences = new[] { "product" }
                    //};
                });
            //...
            services.AddOcelot();
            //services.AddOcelot();
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
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseOcelot().Wait();

        }
    }
}
