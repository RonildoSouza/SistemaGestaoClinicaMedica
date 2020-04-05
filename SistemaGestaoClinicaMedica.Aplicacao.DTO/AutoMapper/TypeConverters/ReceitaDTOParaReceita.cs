using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class ReceitaDTOParaReceita : ITypeConverter<ReceitaDTO, Receita>
    {
        private readonly IMedicamentoServico _medicamentoServico;
        private readonly IConsultaServico _consultaServico;

        public ReceitaDTOParaReceita(IMedicamentoServico medicamentoServico, IConsultaServico consultaServico)
        {
            _medicamentoServico = medicamentoServico;
            _consultaServico = consultaServico;
        }

        public Receita Convert(ReceitaDTO source, Receita destination, ResolutionContext context)
        {
            List<ReceitaMedicamento> medicamentos = ConstroiListaDeMedicamentos(source.ReceitaMedicamentos).ToList();
            Consulta consulta = _consultaServico.Obter(source.ConsultaId);

            return new Receita(source.Id, source.Observacao, medicamentos, consulta);
        }

        private IEnumerable<ReceitaMedicamento> ConstroiListaDeMedicamentos(List<ReceitaMedicamentoDTO> receitaMedicamentos)
        {
            foreach (var recMed in receitaMedicamentos)
            {
                var medicamento = _medicamentoServico.Obter(recMed.MedicamentoId);
                yield return new ReceitaMedicamento
                {
                    Id = recMed.Id,
                    Medicamento = medicamento,
                    Ativo = recMed.Ativo
                };
            }
        }
    }
}
