using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.AutoMapper
{
    public class DTOParaViewModel : Profile
    {
        public DTOParaViewModel()
        {
            CreateMap<AdministradorDTO, UsuarioViewModel>().ConvertUsing<AdministradorDTOParaUsuarioViewModel>();
            CreateMap<MedicoDTO, UsuarioViewModel>().ConvertUsing<MedicoDTOParaUsuarioViewModel>();
            CreateMap<RecepcionistaDTO, UsuarioViewModel>().ConvertUsing<RecepcionistaDTOParaUsuarioViewModel>();
            CreateMap<LaboratorioDTO, UsuarioViewModel>().ConvertUsing<LaboratorioDTOParaUsuarioViewModel>();
        }
    }
}
