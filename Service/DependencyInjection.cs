using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
        }
    }
}
