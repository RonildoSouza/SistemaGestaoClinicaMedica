using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class MedicamentoEntradaDTOParaMedicamento : ITypeConverter<MedicamentoEntradaDTO, Medicamento>
    {
        private readonly IFabricanteServico _fabricanteServico;

        public MedicamentoEntradaDTOParaMedicamento(IFabricanteServico fabricanteServico)
        {
            _fabricanteServico = fabricanteServico;
        }

        public Medicamento Convert(MedicamentoEntradaDTO source, Medicamento destination, ResolutionContext context)
        {
            Fabricante fabricante = null;

            if (Guid.TryParse(source.FabricanteId, out Guid fabricanteId))
                fabricante = _fabricanteServico.Obter(fabricanteId);

            return new Medicamento(
                source.Id,
                source.Nome.ToUpper(),
                source.NomeFabrica,
                source.Tarja,
                source.Ativo,
                fabricante ?? new Fabricante(fabricanteId, source.FabricanteNome.ToUpper()));
        }
    }
}
