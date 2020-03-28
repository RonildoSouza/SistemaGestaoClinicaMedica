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
            CreateMap<Usuario, LoginEntradaAutenticacaoDTO>()
                .ForMember(dest => dest.CargoId, opt => opt.MapFrom(src => src.Cargo.Id));

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore());

            CreateMap<Administrador, AdministradorDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usuario.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Usuario.Telefone))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Usuario.Senha))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Usuario.Cargo))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Usuario.Ativo));

            CreateMap<Medico, MedicoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usuario.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Usuario.Telefone))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Usuario.Senha))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Usuario.Cargo))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Usuario.Ativo));

            CreateMap<Recepcionista, RecepcionistaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usuario.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Usuario.Telefone))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Usuario.Senha))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Usuario.Cargo))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Usuario.Ativo));

            CreateMap<Laboratorio, LaboratorioDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usuario.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Usuario.Telefone))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Usuario.Senha))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Usuario.Cargo))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Usuario.Ativo));

            CreateMap<Especialidade, EspecialidadeDTO>();

            CreateMap<MedicoEspecialidade, MedicoEspecialidadeDTO>()
                .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(src => src.Especialidade.Id));

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

            CreateMap<Exame, ExameDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Id.ToString().Substring(0, 8).ToUpper()));

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

            CreateMap<HorarioDeTrabalho, HorarioDeTrabalhoDTO>();
        }
    }
}
