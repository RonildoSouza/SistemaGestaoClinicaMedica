using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

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
            Fabricante fabricante = _fabricanteServico.Obter(source.FabricanteNome)
                                    ?? new Fabricante(source.FabricanteId, source.FabricanteNome.ToUpper());

            return new Medicamento(
                source.Id,
                source.Nome.ToUpper(),
                source.NomeFabrica,
                source.Tarja,
                source.Ativo,
                fabricante);
        }
    }
}
