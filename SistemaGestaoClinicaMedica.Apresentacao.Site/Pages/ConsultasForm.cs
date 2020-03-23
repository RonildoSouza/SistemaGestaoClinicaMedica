using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ConsultasForm
    {
        private string _statusConsulta = "Concluida";

        [Inject] public IStatusConsultaServico StatusConsultaServico { get; set; }
        [Inject] public IAtestadoServico AtestadoServico { get; set; }
        [Inject] public ITipoDeAtestadoServico TipoDeAtestadoServico { get; set; }

        public List<StatusConsultaDTO> StatusConsulta { get; set; } = new List<StatusConsultaDTO>();
        public List<TipoDeAtestadoDTO> TiposDeAtestados { get; set; } = new List<TipoDeAtestadoDTO>();
        public AtestadoDTO Atestado { get; set; } = new AtestadoDTO();

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            Atestado.ConsultaId = _dto.Id;
            StatusConsulta = await StatusConsultaServico.GetAsync();
            TiposDeAtestados = await TipoDeAtestadoServico.GetAsync();
        }

        protected override Task Salvar(EditContext editContext)
        {
            _dto.StatusConsultaId = _statusConsulta;
            return base.Salvar(editContext);
        }

        private async Task SalvarAtestado()
        {
            HttpResponseMessage httpResponse;

            httpResponse = await AtestadoServico.PostAsync(Atestado);

            if (httpResponse.IsSuccessStatusCode)
                ToastService.ShowSuccess("Registro salvo com sucesso");
            else
                ToastService.ShowError("Falha ao tentar salvar o registro!");
        }

        private void SelecionaTipoDeAtestado(ChangeEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value.ToString()))
                return;

            Atestado.TipoDeAtestado = new TipoDeAtestadoDTO { Id = args.Value.ToString() };
        }
    }
}
