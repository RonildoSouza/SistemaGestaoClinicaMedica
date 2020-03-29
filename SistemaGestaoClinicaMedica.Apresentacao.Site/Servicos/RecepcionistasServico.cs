using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class RecepcionistasServico : ServicoBase<RecepcionistaDTO, Guid>, IRecepcionistasServico
    {
        public RecepcionistasServico(IConfiguration configuration) : base(configuration) { }
    }
}
