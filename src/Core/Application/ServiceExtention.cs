using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Repositores;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static  class ServiceExtention
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //Add services to the container.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //services.AddScoped<IProductRepositories,>();
        }
    }
}
