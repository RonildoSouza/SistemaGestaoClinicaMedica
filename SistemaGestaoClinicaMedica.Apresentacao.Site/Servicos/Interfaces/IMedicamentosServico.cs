using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IMedicamentosServico : IServicoBase<MedicamentoDTO, Guid>
    {
        Task<List<MedicamentoDTO>> GetPorNomeAsync(string nome);
    }
}
