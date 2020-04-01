using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class UsuariosServico : ServicoBase<UsuarioDTO, Guid>, IUsuariosServico
    {
        public UsuariosServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
