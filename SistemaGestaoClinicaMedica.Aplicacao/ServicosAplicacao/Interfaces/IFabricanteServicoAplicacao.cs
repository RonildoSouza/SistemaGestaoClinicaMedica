using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFabricanteServicoAplicacao : IServicoAplicacaoLeitura<FabricanteDTO, Guid>
    {
        FabricanteDTO Obter(string nome);
    }
}
