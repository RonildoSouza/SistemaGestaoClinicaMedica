using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class FabricantesServico : ServicoBaseLeitura<FabricanteDTO, Guid>, IFabricantesServico
    {
        public FabricantesServico(IConfiguration configuration, ILocalStorageService localStorage) : base(configuration, localStorage) { }

        public async Task<List<FabricanteDTO>> GetPorNomeAsync(string nome)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-nome/{nome}");
            return JsonToDTO<List<FabricanteDTO>>(response);
        }
    }
}
