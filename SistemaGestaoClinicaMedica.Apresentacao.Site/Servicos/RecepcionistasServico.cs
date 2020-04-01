using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class RecepcionistasServico : ServicoBase<RecepcionistaDTO, Guid>, IRecepcionistasServico
    {
        public RecepcionistasServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
