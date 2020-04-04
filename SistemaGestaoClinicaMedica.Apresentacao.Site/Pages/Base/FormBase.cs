using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public abstract class FormBase<TServico, TDTO, TId> : ComponentBase
        where TDTO : IDTO<TId>
        where TServico : IServicoBase<TDTO, TId>
    {
        [Parameter] public TId Id { get; set; }

        [Inject] public ILocalStorageService LocalStorage { get; set; }
        [Inject] public IToastService ToastService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public TServico HttpServico { get; set; }

        protected TDTO _dto = (TDTO)Activator.CreateInstance(typeof(TDTO));
        protected abstract string AposSalvarRetonarPara { get; }

        protected override async Task OnParametersSetAsync()
        {
            if (!default(TId).Equals(Id))
                _dto = await HttpServico.GetAsync(Id);
        }

        protected virtual async Task<bool> Salvar(EditContext editContext)
        {
            if (!editContext.Validate())
                return false;

            HttpResponseMessage httpResponse;

            if (!default(TId).Equals(Id))
                httpResponse = await HttpServico.PutAsync(Id, _dto);
            else
                httpResponse = await HttpServico.PostAsync(_dto);

            if (httpResponse.IsSuccessStatusCode)
                ToastService.ShowSuccess("Registro salvo com sucesso");
            else
            {
                ToastService.ShowError("Falha ao tentar salvar o registro!");
                return false;
            }

            NavigationManager.NavigateTo(AposSalvarRetonarPara);
            return true;
        }
    }
}
