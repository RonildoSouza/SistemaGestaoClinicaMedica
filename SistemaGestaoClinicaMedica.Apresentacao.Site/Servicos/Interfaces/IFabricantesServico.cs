using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IFabricantesServico : IServicoLeituraBase<FabricanteDTO, Guid>
    {
        Task<List<FabricanteDTO>> GetPorNomeAsync(string nome);
    }
}
