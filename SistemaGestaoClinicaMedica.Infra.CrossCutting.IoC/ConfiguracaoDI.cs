using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC
{
    public class ConfiguracaoDI
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddSingleton<IAutenticacaoServico, JwtAutenticacaoServico>();
        }
    }
}
