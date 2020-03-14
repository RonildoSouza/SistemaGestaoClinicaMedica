using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IConsultaServico : IServicoBase<Guid, ConsultaSaidaDTO, ConsultaEntradaDTO>
    {
    }
}
