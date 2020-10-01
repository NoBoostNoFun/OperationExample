using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;

namespace WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddClaimWorkflow()
                .AddClaimRepository()
                .AddNotifications()
                .AddControllers()
                .AddNewtonsoftJson(o =>
                    o.SerializerSettings.Converters.Add(new StringEnumConverter()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                    endpoints.MapControllers());
        }
    }
}
