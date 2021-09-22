using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Cors = Configuration.GetSection("Cors");
        }

        public IConfiguration Configuration { get; }

        public IConfigurationSection Cors { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Resolving Dependency Injection
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IDataProvider, DataProvider>();

            // Adding CORS to application
            services.AddCors(options =>
            {

                options.AddPolicy(name: Cors.GetValue<string>("PolicyName"),
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            // for real time applications JWT authentication is added to increase the security
            // as of now i didnt implemented it as it is out of the scope of the assignment

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(Cors.GetValue<string>("PolicyName"));
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
