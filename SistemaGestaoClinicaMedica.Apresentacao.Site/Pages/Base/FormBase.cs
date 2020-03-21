using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public abstract class FormBase<TServico, TDTO, TId> : ComponentBase
        where TDTO : IDTO<TId>
        where TServico : IServicoBase<TDTO, TId>
    {
        [Parameter] public TId Id { get; set; }

        [Inject] public ILocalStorageService LocalStorage { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public TServico HttpServico { get; set; }

        public TDTO _dto = (TDTO)Activator.CreateInstance(typeof(TDTO));

        protected abstract string AposSalvarRetonarPara { get; }

        protected override async Task OnParametersSetAsync()
        {
            if (!default(TId).Equals(Id))
                _dto = await HttpServico.GetAsync(Id);
        }

        protected virtual async Task Salvar(EditContext editContext)
        {
            if (!editContext.Validate())
                return;

            if (!default(TId).Equals(Id))
                await HttpServico.PutAsync(Id, _dto);
            else
                await HttpServico.PostAsync(_dto);

            NavigationManager.NavigateTo(AposSalvarRetonarPara);
        }
    }
}
