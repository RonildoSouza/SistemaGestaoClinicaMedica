using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFabricanteServicoAplicacao : IServicoAplicacaoLeitura<FabricanteSaidaDTO, Guid>
    {
        FabricanteSaidaDTO Obter(string nome);
    }
}
