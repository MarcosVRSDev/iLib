using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ILib.Servicos
{
    public static class InjecaoDependencias
    {
        public static IServiceCollection AddServicos(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
