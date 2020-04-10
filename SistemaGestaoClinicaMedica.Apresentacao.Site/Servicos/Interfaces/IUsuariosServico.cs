using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IUsuariosServico : IServicoBase<UsuarioDTO, Guid>
    {
        Task<List<UsuarioDTO>> GetTudoComFiltrosAsync(string busca, bool ativo = true);
        Task<UsuarioDTO> GetPorEmailAsync(string email);
    }
}
