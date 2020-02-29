using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class FuncionarioEntradaDTOParaMedico : ITypeConverter<FuncionarioEntradaDTO, Medico>
    {
        public Medico Convert(FuncionarioEntradaDTO source, Medico destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var listaHorarioDeTrabalho = context.Mapper.Map<List<HorarioDeTrabalho>>(source.HorariosDeTrabalho);
            var listaMedicoEspecialidade = context.Mapper.Map<List<MedicoEspecialidade>>(source.MedicoEspecialidades);

            var medico = new Medico(
                source.CRM,
                funcionario,
                listaHorarioDeTrabalho,
                listaMedicoEspecialidade);

            return medico;
        }
    }
}
