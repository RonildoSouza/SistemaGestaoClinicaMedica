using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Consultas
    {
        [Inject]
        private IConsultaServico ConsultaServico { get; set; }

        private List<ConsultaDTO> consultas;

        protected override async Task OnInitializedAsync()
        {
            consultas = await ConsultaServico.GetAsync();
        }
    }
}
