

using Gz.SmartParking.Server.Common;
using Gz.SmartParking.Server.ICommon;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
namespace Gz.SmartParking.Server.Startt
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
            // 使用完整命名空间注册服务
            services.AddTransient<IAppConfiguration, AppConfiguration>();
            services.AddTransient<IDbConnectionFactory,DbConnectionFactory>();
            services.AddTransient<IService.IFileUpgradeService, Service.FileUpgradeService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gz.SmartParking.Server.Start", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gz.SmartParking.Server.Start v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}