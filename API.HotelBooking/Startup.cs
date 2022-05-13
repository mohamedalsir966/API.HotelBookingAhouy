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
using FluentValidation;
using MediatR;
using Service.PipelineBehaviours;

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
            services.AddAutoMapper(GetType().Assembly, typeof(FacilityHotelProfile).Assembly);



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
