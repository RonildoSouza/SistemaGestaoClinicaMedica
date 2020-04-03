using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Storage;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC.Extensions;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using SistemaGestaoClinicaMedica.Infra.Data.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddSingleton<IAutenticacaoServico, JwtAutenticacaoServico>();

            services.RegistrarTudoPorAssembly(typeof(IServicoAplicacaoBase<,>).Assembly, "ServicoAplicacao");

            services.RegistrarTudoPorAssembly(typeof(ServicoBase<,>).Assembly, "Servico");

            services.RegistrarTudoPorAssembly(typeof(IQueryBase<>).Assembly, "Query");

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(typeof(DTOParaEntidade), typeof(EntidadeParaDTO));

            services.AddScoped(typeof(IAzureStorage), typeof(AzureStorage));
        }
    }
}
