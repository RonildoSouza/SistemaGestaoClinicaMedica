using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper
{
    public class DTOParaEntidade : Profile
    {
        public DTOParaEntidade()
        {
            CreateMap<UsuarioDTO, Usuario>().ConvertUsing<UsuarioDTOParaUsuario>();
            CreateMap<AdministradorDTO, Administrador>().ConvertUsing<AdministradorDTOParaAdministrador>();
            CreateMap<MedicoDTO, Medico>().ConvertUsing<MedicoDTOParaMedico>();
            CreateMap<RecepcionistaDTO, Recepcionista>().ConvertUsing<RecepcionistaDTOParaRecepcionista>();
            CreateMap<LaboratorioDTO, Laboratorio>().ConvertUsing<LaboratorioDTOParaLaboratorio>();

            CreateMap<HorarioDeTrabalhoDTO, HorarioDeTrabalho>()
                .ForMember(dest => dest.DiaDaSemana, opt => opt.MapFrom(src => (DayOfWeek)src.DiaDaSemana))
                .ForMember(dest => dest.Inicio, opt => opt.MapFrom(src => TryParse(src.Inicio)))
                .ForMember(dest => dest.InicioIntervalo, opt => opt.MapFrom(src => TryParse(src.InicioIntervalo)))
                .ForMember(dest => dest.FimIntervalo, opt => opt.MapFrom(src => TryParse(src.FimIntervalo)))
                .ForMember(dest => dest.Fim, opt => opt.MapFrom(src => TryParse(src.Fim)));

            CreateMap<MedicoEspecialidadeDTO, MedicoEspecialidade>()
                .ForMember(dest => dest.Medico, opt => opt.Ignore());

            CreateMap<MedicamentoDTO, Medicamento>().ConvertUsing<MedicamentoDTOParaMedicamento>();

            CreateMap<PacienteDTO, Paciente>();

            CreateMap<ConsultaDTO, Consulta>().ConvertUsing<ConsultaDTOParaConsulta>();

            CreateMap<ExameDTO, Exame>().ConvertUsing<ExameDTOParaExame>();

            CreateMap<AtestadoDTO, Atestado>().ConvertUsing<AtestadoDTOParaAtestado>();

            CreateMap<ReceitaDTO, Receita>().ConvertUsing<ReceitaDTOParaReceita>();
        }

        private TimeSpan TryParse(string time)
        {
            if (!TimeSpan.TryParse(time, out TimeSpan timeSpan))
                timeSpan = TimeSpan.Zero;

            return timeSpan;
        }
    }
}
