using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class AdministradoresServico : ServicoBase<AdministradorDTO, Guid>, IAdministradoresServico
    {
        public AdministradoresServico(IConfiguration configuration) : base(configuration) { }
    }
}
