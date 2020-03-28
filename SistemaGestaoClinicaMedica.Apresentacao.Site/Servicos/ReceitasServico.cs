using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ReceitasServico : ServicoBase<ReceitaDTO, Guid>, IReceitasServico
    {
        public ReceitasServico(IConfiguration configuration) : base(configuration) { }

        public async Task<ReceitaDTO> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-consulta/{consultaId}");
            return JsonToDTO<ReceitaDTO>(response);
        }
    }
}
