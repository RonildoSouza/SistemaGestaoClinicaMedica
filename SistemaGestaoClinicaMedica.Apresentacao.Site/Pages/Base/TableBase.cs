using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public abstract class TableBase<TServico, TDTO, TId> : ComponentBase
        where TDTO : IDTO<TId>
        where TServico : IServicoBase<TDTO, TId>
    {
        [Inject] public ILocalStorageService LocalStorage { get; set; }
        [Inject] public IToastService ToastService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public TServico HttpServico { get; set; }

        public List<TDTO> dtos;

        protected async override Task OnParametersSetAsync()
        {
            await CarregaDadosDaTabela();
        }

        protected virtual async Task Deletar(MouseEventArgs e, TId id)
        {
            if (default(TId).Equals(id))
                return;

            await HttpServico.DeleteAsync(id);
            await CarregaDadosDaTabela();
        }

        protected virtual async Task CarregaDadosDaTabela()
        {
            dtos = await HttpServico.GetAsync();
        }
    }
}
