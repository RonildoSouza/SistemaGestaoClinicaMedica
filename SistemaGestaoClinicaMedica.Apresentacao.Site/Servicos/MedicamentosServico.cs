using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicamentosServico : ServicoBase<MedicamentoDTO, Guid>, IMedicamentosServico
    {
        public MedicamentosServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<List<MedicamentoDTO>> GetPorNomeAsync(string nome)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-nome/{nome}");
            return JsonToDTO<List<MedicamentoDTO>>(response);
        }
    }
}
