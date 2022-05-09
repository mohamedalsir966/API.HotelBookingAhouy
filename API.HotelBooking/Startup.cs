using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Extension;
using Service;
using System.IO;
using Service.Mapper;
using System.Text.Json.Serialization;

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
            services.AddScopedServices();
            services.AddSwaggerOpenAPI();
            services.AddServiceLayer();
            services.AddAutoMapper(GetType().Assembly, typeof(HotelProfile).Assembly);
            services.AddAutoMapper(GetType().Assembly, typeof(LookupProfile).Assembly); 


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();
            app.ConfigureSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
