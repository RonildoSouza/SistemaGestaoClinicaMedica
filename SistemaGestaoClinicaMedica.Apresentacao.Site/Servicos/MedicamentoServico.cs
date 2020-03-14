using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicamentoServico : ServicoBase<Guid, MedicamentoSaidaDTO, MedicamentoEntradaDTO>, IMedicamentoServico
    {
        protected override string EndPoint => "medicamentos";

        public MedicamentoServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
