using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegistrarTudoPorAssembly(this IServiceCollection services, Assembly assembly, string endsWith, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var typeImplementacoes = assembly.GetTypes().Where(_ => !_.IsAbstract && !_.IsInterface && _.Name.EndsWith(endsWith));
            var typeInterfaces = typeImplementacoes.SelectMany(_ => _.GetInterfaces().Where(_ => _.Name.EndsWith(endsWith)));

            foreach (var typeInterface in typeInterfaces)
            {
                var typeImplementacao = typeImplementacoes.Single(_ => _.GetInterface(typeInterface.Name) != null);
                services.Add(ServiceDescriptor.Describe(typeInterface, typeImplementacao, serviceLifetime));
            }
        }
    }
}
