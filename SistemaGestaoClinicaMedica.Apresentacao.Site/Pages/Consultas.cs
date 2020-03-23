using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Consultas
    {
        private string _statusConsultaSelecionado = "Agendada";

        [Inject] public IConsultaServico ConsultaServico { get; set; }
        [Inject] public IStatusConsultaServico StatusConsultaServico { get; set; }

        private DateTime DataInicio { get; set; }
        private DateTime DataFim { get; set; }
        private string Busca { get; set; }
        public List<StatusConsultaDTO> StatusConsulta { get; set; } = new List<StatusConsultaDTO>();
        //private List<MedicoDTO> Medicos { get; set; }

        protected async override Task OnInitializedAsync()
        {
            DataInicio = DateTime.Today;
            DataFim = DataInicio.AddMonths(1);
            StatusConsulta = await StatusConsultaServico.GetAsync();

            await base.OnInitializedAsync();
        }

        private void SelecionaStatusConsulta(ChangeEventArgs args)
        {
            var statusSelecionado = args.Value.ToString();
            if (string.IsNullOrEmpty(statusSelecionado))
                return;

            _statusConsultaSelecionado = statusSelecionado;
        }

        private async Task Buscar()
        {
            await CarregaDadosDaTabela();
        }

        protected async override Task CarregaDadosDaTabela()
        {
            dtos = await HttpServico.GetTudoComFiltrosAsync(DataInicio, DataFim, Busca, _statusConsultaSelecionado);
            StateHasChanged();
        }
    }
}
