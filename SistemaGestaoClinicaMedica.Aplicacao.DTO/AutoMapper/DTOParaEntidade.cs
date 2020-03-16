using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper
{
    public class DTOParaEntidade : Profile
    {
        public DTOParaEntidade()
        {
            CreateMap<FuncionarioDTO, Funcionario>().ConvertUsing<FuncionarioDTOParaFuncionario>();
            CreateMap<FuncionarioDTO, Administrador>().ConvertUsing<FuncionarioDTOParaAdministrador>();
            CreateMap<FuncionarioDTO, Medico>().ConvertUsing<FuncionarioDTOParaMedico>();
            CreateMap<FuncionarioDTO, Recepcionista>().ConvertUsing<FuncionarioDTOParaRecepcionista>();
            CreateMap<FuncionarioDTO, Laboratorio>().ConvertUsing<FuncionarioDTOParaLaboratorio>();

            CreateMap<HorarioDeTrabalhoDTO, HorarioDeTrabalho>()
                .ForMember(dest => dest.DiaDaSemana, opt => opt.MapFrom(src => (DayOfWeek)src.DiaDaSemana))
                .ForMember(dest => dest.Inicio, opt => opt.MapFrom(src => TryParse(src.Inicio)))
                .ForMember(dest => dest.InicioAlmoco, opt => opt.MapFrom(src => TryParse(src.InicioAlmoco)))
                .ForMember(dest => dest.FimAlmoco, opt => opt.MapFrom(src => TryParse(src.FimAlmoco)))
                .ForMember(dest => dest.Fim, opt => opt.MapFrom(src => TryParse(src.Fim)));

            CreateMap<MedicoEspecialidadeDTO, MedicoEspecialidade>()
                .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(src => Guid.Parse(src.EspecialidadeId)));

            CreateMap<MedicamentoDTO, Medicamento>().ConvertUsing<MedicamentoDTOParaMedicamento>();

            CreateMap<PacienteDTO, Paciente>();

            CreateMap<ConsultaDTO, Consulta>().ConvertUsing<ConsultaDTOParaConsulta>();

            CreateMap<ExameDTO, Exame>().ConvertUsing<ExameDTOParaExame>();

            CreateMap<AtestadoDTO, Atestado>().ConvertUsing<AtestadoDTOParaAtestado>();

            CreateMap<ReceitaDTO, Receita>().ConvertUsing<ReceitaDTOParaReceita>();
        }

        private TimeSpan? TryParse(string time)
        {
            TimeSpan.TryParse(time, out TimeSpan timeSpan);
            return timeSpan;
        }
    }
}
