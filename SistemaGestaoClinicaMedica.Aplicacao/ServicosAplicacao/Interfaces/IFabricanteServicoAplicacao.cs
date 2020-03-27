using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFabricanteServicoAplicacao : IServicoAplicacaoLeitura<FabricanteDTO, Guid>
    {
        IList<FabricanteDTO> ObterTudoPorNome(string nome);
        FabricanteDTO Obter(string nome);
    }
}
