using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.AutoMapper
{
    public class ViewModelParaDTO : Profile
    {
        public ViewModelParaDTO()
        {
            CreateMap<UsuarioViewModel, AdministradorDTO>().ConvertUsing<UsuarioViewModelParaAdministradorDTO>();
            CreateMap<UsuarioViewModel, MedicoDTO>().ConvertUsing<UsuarioViewModelParaMedicoDTO>();
            CreateMap<UsuarioViewModel, RecepcionistaDTO>().ConvertUsing<UsuarioViewModelParaRecepcionistaDTO>();
            CreateMap<UsuarioViewModel, LaboratorioDTO>().ConvertUsing<UsuarioViewModelParaLaboratorioDTO>();
        }
    }
}
