using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper
{
    public class EntidadeParaDTO : Profile
    {
        public EntidadeParaDTO()
        {
            CreateMap<Funcionario, LoginEntradaAutenticacaoDTO>()
                .ForMember(dest => dest.CargoId, opt => opt.MapFrom(src => src.Cargo.Id));

            CreateMap<Funcionario, FuncionarioDTO>();

            CreateMap<Especialidade, EspecialidadeDTO>();

            CreateMap<MedicoEspecialidade, MedicoEspecialidadeDTO>()
                .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(src => src.Especialidade.Id));

            CreateMap<Laboratorio, LaboratorioSaidaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Funcionario.Nome));

            CreateMap<Cargo, CargoDTO>();

            CreateMap<Medicamento, MedicamentoDTO>()
                .ForMember(dest => dest.FabricanteNome, opt => opt.MapFrom(src => src.Fabricante.Nome));

            CreateMap<Fabricante, FabricanteDTO>();

            CreateMap<Paciente, PacienteDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 4).ToUpper()));

            CreateMap<Consulta, ConsultaDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 6).ToUpper()))
                .ForMember(dest => dest.StatusConsultaId, opt => opt.MapFrom(src => src.StatusConsulta.Id.ToString()))
                .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(src => src.Especialidade.Id));

            CreateMap<Medico, MedicoDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Funcionario.Nome));

            CreateMap<Exame, ExameDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 8).ToUpper()))
                .ForMember(dest => dest.StatusExameId, opt => opt.MapFrom(src => src.StatusExame.Id));

            CreateMap<TipoDeExame, TipoDeExameDTO>();

            CreateMap<StatusConsulta, StatusConsultaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<StatusExame, StatusExameDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<Atestado, AtestadoDTO>()
                .ForMember(dest => dest.ConsultaId, opt => opt.MapFrom(src => src.Consulta.Id));

            CreateMap<TipoDeAtestado, TipoDeAtestadoDTO>();

            CreateMap<Receita, ReceitaDTO>()
                .ForMember(dest => dest.ConsultaId, opt => opt.MapFrom(src => src.Consulta.Id))
                .ForMember(dest => dest.ReceitaMedicamentos, opt => opt.MapFrom(src => src.Medicamentos));

            CreateMap<ReceitaMedicamento, ReceitaMedicamentoDTO>();
        }
    }
}
