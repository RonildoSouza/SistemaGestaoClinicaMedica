using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class RealizaExamesForm
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ApplicationState ApplicationState { get; set; }

        private async Task BuscarAsync(string busca)
        {
            _dto = await HttpServico.GetPorCodigoAsync(busca);
            Id = _dto.Id;
        }

        private async Task EnviarResultadoAsync(IFileListEntry[] files)
        {
            foreach (var file in files)
            {
                var uri = await HttpServico.UploadResultado(_dto.Id, file.Data, file.Name);
                _dto.LinkResultadoExame = uri.AbsoluteUri;
            }
        }

        protected async override Task Salvar(EditContext editContext)
        {
            if (string.IsNullOrEmpty(_dto.LinkResultadoExame))
            {
                ToastService.ShowWarning("Não foi realizado o envio do resultados!");
                return;
            }

            _dto.LaboratorioRealizouExameId = ApplicationState.UsuarioLogado.Id;
            _dto.StatusExame.Id = StatusExameConst.Concluido;

            await HttpServico.PutAsync(_dto.Id, _dto);
            await JSRuntime.ForceReload();
        }
    }
}
