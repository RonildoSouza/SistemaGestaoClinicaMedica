using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using SistemaGestaoClinicaMedica.Infra.Data.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC
{
    public class DominioServicoDI
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddScoped(typeof(IServicoBase<,>), typeof(ServicoBase<,>));

            services.AddScoped<IAdministradorServico, AdministradorServico>();
            //services.AddScoped<IAtestadoServico, AtestadoServico>();
            services.AddScoped<ICargoServico, CargoServico>();
            //services.AddScoped<IConsultaServico, ConsultaServico>();
            //services.AddScoped<IEspecialidadeServico, EspecialidadeServico>();
            //services.AddScoped<IExameServico, ExameServico>();
            //services.AddScoped<IFabricanteServico, FabricanteServico>();
            services.AddScoped<IFuncionarioServico, FuncionarioServico>();
            //services.AddScoped<IHoraioDeTrabalhoServico, HoraioDeTrabalhoServico>();
            services.AddScoped<ILaboratorioServico, LaboratorioServico>();
            //services.AddScoped<IMedicamentoServico, MedicamentoServico>();
            services.AddScoped<IMedicoServico, MedicoServico>();
            services.AddScoped<IMedicoEspecialidadeServico, MedicoEspecialidadeServico>();
            //services.AddScoped<IReceitaServico, ReceitaServico>();
            services.AddScoped<IRecepcionistaServico, RecepcionistaServico>();
            //services.AddScoped<IStatusConsultaServico, StatusConsultaServico>();
            //services.AddScoped<IStatusExameServico, StatusExameServico>();
            //services.AddScoped<ITipoDeAtestadoServico, TipoDeAtestadoServico>();
            //services.AddScoped<ITipoDeExameServico, TipoDeExameServico>();

            services.AddScoped<IFuncionarioQueries, FuncionarioQueries>();
        }
    }
}
