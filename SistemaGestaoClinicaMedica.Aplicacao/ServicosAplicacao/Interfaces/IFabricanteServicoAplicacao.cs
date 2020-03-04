using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFabricanteServicoAplicacao : IServicoAplicacaoLeitura<FabricanteSaidaDTO, Guid>
    {
        IList<FabricanteSaidaDTO> ObterTudo(string nome);
    }
}
