using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Consultas
    {
        private DateTime _dataInicio;
        private DateTime _dataFim;
        private List<StatusConsultaDTO> _statusConsulta = new List<StatusConsultaDTO>();
        private string _statusConsultaSelecionado = StatusConsultaConst.Agendada;
        private string _busca;

        [Inject] private IStatusConsultasServico StatusConsultaServico { get; set; }
        [Inject] private ApplicationState ApplicationState { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _dataInicio = DateTime.Today;
            _dataFim = _dataInicio.AddMonths(1);
            _statusConsulta = await StatusConsultaServico.GetAsync();

            await base.OnInitializedAsync();
        }

        private void SelecionaStatusConsulta(ChangeEventArgs args)
        {
            _statusConsultaSelecionado = args.Value.ToString();
        }

        private async Task BuscarAsync(string busca)
        {
            _busca = busca;
            await CarregaDadosDaTabela();
        }

        protected async override Task CarregaDadosDaTabela()
        {
            Guid? medicoId = null;

            if (ApplicationState.UsuarioLogado.CargoId == CargosConst.Medico)
                medicoId = ApplicationState.UsuarioLogado.Id;

            dtos = await HttpServico.GetTudoComFiltrosAsync(_dataInicio, _dataFim, _busca, _statusConsultaSelecionado, medicoId);
            StateHasChanged();
        }
    }
}
