using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class MedicoDTOParaMedico : ITypeConverter<MedicoDTO, Medico>
    {
        private readonly IMedicoServico _medicoServico;

        public MedicoDTOParaMedico(IMedicoServico medicoServico)
        {
            _medicoServico = medicoServico;
        }

        public Medico Convert(MedicoDTO source, Medico destination, ResolutionContext context)
        {
            source.Cargo.Id = "Medico";

            var usuario = context.Mapper.Map<Usuario>(source);
            var listaHorarioDeTrabalho = context.Mapper.Map<List<HorarioDeTrabalho>>(source.HorariosDeTrabalho);
            var listaMedicoEspecialidade = context.Mapper.Map<List<MedicoEspecialidade>>(source.Especialidades);

            var medico = new Medico(
                source.CRM,
                usuario,
                listaHorarioDeTrabalho,
                listaMedicoEspecialidade)
            {
                // Recupera id da tabela de relacionamento
                Id = _medicoServico.Obter(usuario.Id, true)?.Id ?? Guid.Empty
            };

            return medico;
        }
    }
}
