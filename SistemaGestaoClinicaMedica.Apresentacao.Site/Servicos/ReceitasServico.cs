using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ReceitasServico : ServicoBase<ReceitaDTO, Guid>, IReceitasServico
    {
        public ReceitasServico(IConfiguration configuration, ILocalStorageService localStorage) : base(configuration, localStorage) { }

        public async Task<ReceitaDTO> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-consulta/{consultaId}");
            return JsonToDTO<ReceitaDTO>(response);
        }
    }
}
