using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class FabricantesServico : ServicoBaseLeitura<FabricanteDTO, Guid>, IFabricantesServico
    {
        public FabricantesServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<List<FabricanteDTO>> GetPorNomeAsync(string nome)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-nome/{nome}");
            return JsonToDTO<List<FabricanteDTO>>(response);
        }
    }
}
