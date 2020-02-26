using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroService.Api
{
    /// <summary>
    /// Configures Application and Services
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructs Startup instance
        /// </summary>
        /// <param name="configuration">Application Configuration Settings</param>
        public Startup(IConfiguration configuration)
        {
            _ = configuration;
        }

        /// <summary>
        /// Configures Services and Dependency Injection
        /// </summary>
        /// <param name="services">Service Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Services.ISalesService, Services.ConsolidatedInMemorySalesService>();
            services.AddControllers();

            services.AddSwaggerDefinition(typeof(Startup).Assembly);
        }

        /// <summary>
        /// Configures the Application Request Pipelines
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">WebHost Environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Micro Service API V1");
            });
        }
    }
}
