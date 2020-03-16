using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicamentoServico : ServicoBase<MedicamentoDTO, Guid>, IMedicamentoServico
    {
        protected override string EndPoint => "medicamentos";

        public MedicamentoServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
