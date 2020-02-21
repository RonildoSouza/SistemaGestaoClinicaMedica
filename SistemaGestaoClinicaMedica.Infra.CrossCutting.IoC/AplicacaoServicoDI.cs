using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC
{
    public class AplicacaoServicoDI
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddScoped<ILoginServicoAplicacao, LoginServicoAplicacao>();

            ///services.AddScoped<IAdministradorServicoAplicacao, AdministradorServicoAplicacao>();
            //services.AddScoped<IAtestadoServicoAplicacao, AtestadoServicoAplicacao>();
            //services.AddScoped<ICargoServicoAplicacao, CargoServicoAplicacao>();
            //services.AddScoped<IConsultaServicoAplicacao, ConsultaServicoAplicacao>();
            //services.AddScoped<IEspecialidadeServicoAplicacao, EspecialidadeServicoAplicacao>();
            //services.AddScoped<IExameServicoAplicacao, ExameServicoAplicacao>();
            //services.AddScoped<IFabricanteServicoAplicacaoAplicacao, FabricanteServicoAplicacao>();
            services.AddScoped<IFuncionarioServicoAplicacao, FuncionarioServicoAplicacao>();
            //services.AddScoped<IHoraioDeTrabalhoServicoAplicacao, HoraioDeTrabalhoServicoAplicacao>();
            //services.AddScoped<IMedicamentoServicoAplicacao, MedicamentoServicoAplicacao>();
            ///services.AddScoped<IMedicoServicoAplicacao, MedicoServicoAplicacao>();
            //services.AddScoped<IReceitaServicoAplicacao, ReceitaServicoAplicacao>();
            ///services.AddScoped<IRecepcionistaServicoAplicacao, RecepcionistaServicoAplicacao>();
            //services.AddScoped<IStatusConsultaServicoAplicacao, StatusConsultaServicoAplicacao>();
            //services.AddScoped<IStatusExameServicoAplicacao, StatusExameServicoAplicacao>();
            //services.AddScoped<ITipoDeAtestadoServicoAplicacao, TipoDeAtestadoServicoAplicacao>();
            //services.AddScoped<ITipoDeExameServicoAplicacao, TipoDeExameServicoAplicacao>();
        }
    }
}
