using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Extension;
using Service;
using Service.Cache;

namespace API.HotelBooking
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
            services.AddControllers();
            services.AddDbContext(Configuration);
            #region her we register DI in ConfigureServiceContainer
            #endregion
            services.AddScopedServices();
            services.AddSwaggerOpenAPI();
            #region her we add Mediator piplin and mapin profile DependencyInjection
            #endregion
            services.AddServiceLayer();
            services.AddDistributedRedisCache(o =>
            {
                o.Configuration = Configuration.GetValue<string>("Redis:ConnectionString");
            });
            services.AddScoped<CacheService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();
            app.ConfigureSwagger();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
