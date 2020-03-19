using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ConsultasForm
    {
        [Inject]
        private IEspecialidadeServico EspecialidadeServico { get; set; }

        private List<EspecialidadeDTO> _especialidades = new List<EspecialidadeDTO>();

        protected override async Task OnParametersSetAsync()
        {
            _especialidades = await EspecialidadeServico.GetAsync();
            await base.OnParametersSetAsync();
        }
    }
}
