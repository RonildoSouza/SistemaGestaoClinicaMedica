using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters
{
    public class LaboratorioDTOParaUsuarioViewModel : UsuarioDTOParaUsuarioViewModelBase<LaboratorioDTO>
    {
        public override UsuarioViewModel Convert(LaboratorioDTO source, UsuarioViewModel destination, ResolutionContext context)
        {
            destination = base.Convert(source, destination, context);
            destination.DaClinica = source.DaClinica;

            return destination;
        }
    }
}
