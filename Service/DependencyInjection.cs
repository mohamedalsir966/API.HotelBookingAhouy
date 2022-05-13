using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using Service.PipelineBehaviours;
using Service.Mapper;
using AutoMapper;

namespace Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            var config = new MapperConfiguration(c => {
                c.AddProfile<HotelProfile>();
                c.AddProfile<LookupProfile>();
                c.AddProfile<FacilityHotelProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());



        }
    }
}
