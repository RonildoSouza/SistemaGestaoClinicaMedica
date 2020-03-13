using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class ReceitaEntradaDTOParaReceita : ITypeConverter<ReceitaEntradaDTO, Receita>
    {
        private readonly IMedicamentoServico _medicamentoServico;
        private readonly IConsultaServico _consultaServico;

        public ReceitaEntradaDTOParaReceita(IMedicamentoServico medicamentoServico, IConsultaServico consultaServico)
        {
            _medicamentoServico = medicamentoServico;
            _consultaServico = consultaServico;
        }

        public Receita Convert(ReceitaEntradaDTO source, Receita destination, ResolutionContext context)
        {
            List<ReceitaMedicamento> medicamentos = ConstroiListaDeMedicamentos(source.ReceitaMedicamentos).ToList();
            Consulta consulta = _consultaServico.Obter(source.ConsultaId);

            return new Receita(source.Id, source.Observacao, medicamentos, consulta);
        }

        private IEnumerable<ReceitaMedicamento> ConstroiListaDeMedicamentos(List<ReceitaMedicamentoEntradaDTO> receitaMedicamentos)
        {
            foreach (var recMed in receitaMedicamentos)
            {
                var medicamento = _medicamentoServico.Obter(recMed.MedicamentoId);
                yield return new ReceitaMedicamento
                {
                    Id = recMed.Id,
                    Medicamento = medicamento
                };
            }
        }
    }
}
