using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ExameServico : ServicoBase<ExameDTO, Guid>, IExameServico
    {
        protected override string EndPoint => "exames";

        public ExameServico(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ExameDTO> GetPorCodigoAsync(string codigo)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-codigo/{codigo}");
            return JsonToDTO<ExameDTO>(response);
        }
    }
}
