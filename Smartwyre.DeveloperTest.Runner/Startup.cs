using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Core;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.MappProfiles;
using Smartwyre.DeveloperTest.Data.Repository;
using Smartwyre.DeveloperTest.Infrastructure.Services;
using Smartwyre.DeveloperTest.Services;

namespace Smartwyre.DeveloperTest.Runner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = "Server=DESKTOP-IO3SACI\\SQLEXPRESS2016;Database=SW;Trusted_Connection=True;TrustServerCertificate=True";
            services.AddDbContext<SWContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IRebateRepository, RebateRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRebateService, RebateService>();


            services.AddSingleton<IConfiguration>(Configuration);

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(ProductProfile), typeof(RebateProfile));

            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseSwagger();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
