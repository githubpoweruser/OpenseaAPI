using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenseaAPI.Business;
using OpenseaAPI.Business.Interface;
using OpenseaAPI.DataAccess.MyDbContext;

namespace OpenseaAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OpenseaAPI", Version = "v1" });
            });

            #region øÁ”Ú…Ë÷√
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", set =>
                {
                    set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            #endregion

            #region º”‘ÿefcore
            services.AddDbContext<OracleDbContext>(options =>
            {
                options.UseOracle(Configuration.GetConnectionString("OracleConnection"));
            });
            #endregion

            #region “¿¿µ◊¢»Î
            services.AddScoped<ITestLogic, TestLogic>();
            services.AddScoped<IBasicInfoLogic, BasicInfoLogic>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenseaAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
