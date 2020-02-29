using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoClinicaMedica.Aplicacao.AutoMapper;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config
{
    public class AutoMapperConfig
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DTOParaEntidade), typeof(EntidadeParaDTO));
        }
    }
}
