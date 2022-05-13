using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Service.PipelineBehaviours;

namespace Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddAutoMapper(GetType().Assembly, typeof(HotelProfile).Assembly);
            //services.AddAutoMapper(GetType().Assembly, typeof(LookupProfile).Assembly);
            //services.AddAutoMapper(GetType().Assembly, typeof(FacilityHotelProfile).Assembly);
        }
    }
}
