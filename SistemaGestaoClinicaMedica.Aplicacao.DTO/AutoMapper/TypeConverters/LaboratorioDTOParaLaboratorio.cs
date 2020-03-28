using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class LaboratorioDTOParaLaboratorio : ITypeConverter<LaboratorioDTO, Laboratorio>
    {
        private readonly ILaboratorioServico _laboratorioServico;

        public LaboratorioDTOParaLaboratorio(ILaboratorioServico laboratorioServico)
        {
            _laboratorioServico = laboratorioServico;
        }

        public Laboratorio Convert(LaboratorioDTO source, Laboratorio destination, ResolutionContext context)
        {
            source.Cargo.Id = "Laboratorio";

            var usuario = context.Mapper.Map<Usuario>(source);
            var laboratorio = new Laboratorio(usuario, source.DaClinica)
            {
                // Recupera id da tabela de relacionamento
                Id = _laboratorioServico.Obter(usuario.Id, true)?.Id ?? Guid.Empty
            };

            return laboratorio;
        }
    }
}
