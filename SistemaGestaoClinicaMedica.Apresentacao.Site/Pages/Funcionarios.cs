using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Funcionarios
    {
        [Inject]
        private IFuncionarioServico FuncionarioServico { get; set; }

        private List<FuncionarioDTO> funcionarios;

        protected override async Task OnInitializedAsync()
        {
            funcionarios = await FuncionarioServico.GetAsync();
        }
    }
}
