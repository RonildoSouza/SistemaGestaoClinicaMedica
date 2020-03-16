using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class MedicamentoDTOParaMedicamento : ITypeConverter<MedicamentoDTO, Medicamento>
    {
        private readonly IFabricanteServico _fabricanteServico;

        public MedicamentoDTOParaMedicamento(IFabricanteServico fabricanteServico)
        {
            _fabricanteServico = fabricanteServico;
        }

        public Medicamento Convert(MedicamentoDTO source, Medicamento destination, ResolutionContext context)
        {
            Fabricante fabricante = _fabricanteServico.Obter(source.FabricanteNome)
                                    ?? new Fabricante(Guid.Empty, source.FabricanteNome.ToUpper());

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
