using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFabricanteServicoAplicacao
    {
        IList<FabricanteSaidaDTO> ObterTudo(string nome);
    }
}
