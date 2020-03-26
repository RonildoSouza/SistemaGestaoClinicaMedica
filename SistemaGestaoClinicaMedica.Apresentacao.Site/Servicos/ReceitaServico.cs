using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ReceitaServico : ServicoBase<ReceitaDTO, Guid>, IReceitaServico
    {
        protected override string EndPoint => "receitas";

        public ReceitaServico(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ReceitaDTO> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-consulta/{consultaId}");
            return JsonToDTO<ReceitaDTO>(response);
        }
    }
}
