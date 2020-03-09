using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Cargo;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper
{
    public class EntidadeParaDTO : Profile
    {
        public EntidadeParaDTO()
        {
            CreateMap<Funcionario, LoginEntradaAutenticacaoDTO>()
                .ForMember(dest => dest.CargoId, opt => opt.MapFrom(src => src.Cargo.Id));

            CreateMap<Funcionario, FuncionarioSaidaDTO>()
                .ForMember(dest => dest.CargoId, opt => opt.MapFrom(src => src.Cargo.Id));

            CreateMap<Especialidade, EspecialidadeSaidaDTO>();

            CreateMap<MedicoEspecialidade, MedicoEspecialidadeSaidaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Medico.Funcionario.Nome))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(src => src.Medico.CRM));

            CreateMap<Laboratorio, LaboratorioSaidaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Funcionario.Nome));

            CreateMap<Cargo, CargoSaidaDTO>();

            CreateMap<Medicamento, MedicamentoSaidaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => $"{src.Nome} - {src.NomeFabrica}"))
                .ForMember(dest => dest.FabricanteNome, opt => opt.MapFrom(src => src.Fabricante.Nome));

            CreateMap<Fabricante, FabricanteSaidaDTO>();

            CreateMap<Paciente, PacienteSaidaDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 4).ToUpper()))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => $"{src.Bairro}, {src.Cidade} - {src.Estado}"));

            CreateMap<Consulta, ConsultaSaidaDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 6).ToUpper()))
                .ForMember(dest => dest.StatusConsulta, opt => opt.MapFrom(src => src.StatusConsulta.Nome))
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome));

            CreateMap<Medico, MedicoSaidaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Funcionario.Nome));

            CreateMap<Exame, ExameSaidaDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 8).ToUpper()))
                .ForMember(dest => dest.StatusExame, opt => opt.MapFrom(src => src.StatusExame.Nome));

            CreateMap<TipoDeExame, TipoDeExameSaidaDTO>();

            CreateMap<StatusConsulta, StatusConsultaSaidaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<StatusExame, StatusExameSaidaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<Atestado, AtestadoSaidaDTO>()
                .ForMember(dest => dest.ConsultaId, opt => opt.MapFrom(src => src.Consulta.Id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<TipoDeAtestado, TipoDeAtestadoSaidaDTO>();
        }
    }
}
