using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class LaboratoriosServico : ServicoBase<LaboratorioDTO, Guid>, ILaboratoriosServico
    {
        public LaboratoriosServico(IConfiguration configuration, ILocalStorageService localStorage) : base(configuration, localStorage) { }
    }
}
