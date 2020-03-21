using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class FuncionarioDTOParaMedico : ITypeConverter<FuncionarioDTO, Medico>
    {
        private readonly IMedicoServico _medicoServico;

        public FuncionarioDTOParaMedico(IMedicoServico medicoServico)
        {
            _medicoServico = medicoServico;
        }

        public Medico Convert(FuncionarioDTO source, Medico destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var listaHorarioDeTrabalho = context.Mapper.Map<List<HorarioDeTrabalho>>(source.HorariosDeTrabalho);
            var listaMedicoEspecialidade = context.Mapper.Map<List<MedicoEspecialidade>>(source.MedicoEspecialidades);

            var medico = new Medico(
                source.CRM,
                funcionario,
                listaHorarioDeTrabalho,
                listaMedicoEspecialidade);

            var medicoId = _medicoServico.Obter(funcionario.Id, true)?.Id ?? Guid.Empty;
            medico.Id = medicoId;

            return medico;
        }
    }
}
