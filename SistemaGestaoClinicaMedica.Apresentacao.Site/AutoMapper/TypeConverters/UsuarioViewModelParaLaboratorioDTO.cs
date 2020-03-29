using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters
{
    public class UsuarioViewModelParaLaboratorioDTO : UsuarioViewModelParaUsuarioDTOBase<LaboratorioDTO>
    {
        public override LaboratorioDTO Convert(UsuarioViewModel source, LaboratorioDTO destination, ResolutionContext context)
        {
            destination = base.Convert(source, destination, context);
            destination.DaClinica = source.DaClinica;

            return destination;
        }
    }
}
