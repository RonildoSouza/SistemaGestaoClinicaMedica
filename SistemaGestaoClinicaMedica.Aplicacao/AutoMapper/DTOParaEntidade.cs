using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper
{
    public class DTOParaEntidade : Profile
    {
        public DTOParaEntidade()
        {
            CreateMap<FuncionarioEntradaDTO, Funcionario>().ConvertUsing<FuncionarioEntradaDTOParaFuncionario>();
            CreateMap<FuncionarioEntradaDTO, Administrador>().ConvertUsing<FuncionarioEntradaDTOParaAdministrador>();
            CreateMap<FuncionarioEntradaDTO, Medico>().ConvertUsing<FuncionarioEntradaDTOParaMedico>();
            CreateMap<FuncionarioEntradaDTO, Recepcionista>().ConvertUsing<FuncionarioEntradaDTOParaRecepcionista>();
            CreateMap<FuncionarioEntradaDTO, Laboratorio>().ConvertUsing<FuncionarioEntradaDTOParaLaboratorio>();

            CreateMap<HorarioDeTrabalhoEntradaDTO, HorarioDeTrabalho>()
                .ForMember(dest => dest.DiaDaSemana, opt => opt.MapFrom(src => (DayOfWeek)src.DiaDaSemana))
                .ForMember(dest => dest.Inicio, opt => opt.MapFrom(src => TryParse(src.Inicio)))
                .ForMember(dest => dest.InicioAlmoco, opt => opt.MapFrom(src => TryParse(src.InicioAlmoco)))
                .ForMember(dest => dest.FimAlmoco, opt => opt.MapFrom(src => TryParse(src.FimAlmoco)))
                .ForMember(dest => dest.Fim, opt => opt.MapFrom(src => TryParse(src.Fim)));

            CreateMap<MedicoEspecialidadeEntradaDTO, MedicoEspecialidade>()
                .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(src => Guid.Parse(src.EspecialidadeId)));

            CreateMap<MedicamentoEntradaDTO, Medicamento>().ConvertUsing<MedicamentoEntradaDTOParaMedicamento>();

            CreateMap<PacienteEntradaDTO, Paciente>();
        }

        private TimeSpan? TryParse(string time)
        {
            TimeSpan.TryParse(time, out TimeSpan timeSpan);
            return timeSpan;
        }
    }
}
