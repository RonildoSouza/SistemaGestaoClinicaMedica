using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper
{
    public class EntidadeParaDTO : Profile
    {
        public EntidadeParaDTO()
        {
            CreateMap<Funcionario, LoginSaidaDTO>()
                .ForMember(dest => dest.CargoId, opt => opt.MapFrom(src => src.Cargo.Id));

            CreateMap<Funcionario, FuncionarioSaidaDTO>()
                .ForMember(dest => dest.CargoId, opt => opt.MapFrom(src => src.Cargo.Id));

            CreateMap<Especialidade, EspecialidadeSaidaDTO>();

            CreateMap<MedicoEspecialidade, MedicoEspecialidadeSaidaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Medico.Funcionario.Nome))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => src.Medico.CRM));
        }
    }
}
