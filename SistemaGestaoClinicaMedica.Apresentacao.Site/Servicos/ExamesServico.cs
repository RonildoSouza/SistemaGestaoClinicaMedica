using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ExamesServico : ServicoBase<ExameDTO, Guid>, IExamesServico
    {
        public ExamesServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<ExameDTO> GetPorCodigoAsync(string codigo)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-codigo/{codigo}");
            return JsonToDTO<ExameDTO>(response);
        }

        public async Task<Uri> UploadResultado(Guid id, Stream stream, string arquivoNome)
        {
            var m = new MultipartFormDataContent
            {
                { new StreamContent(stream), "file", arquivoNome }
            };

            var response = await ApplicationState.HttpClient.PostAsync($"{ApiEndPoint}/uploadresultado/{id}", m);
            var content = await response.Content.ReadAsStringAsync();
            return JsonToDTO<Uri>(content);
        }

        public async Task<HttpResponseMessage> PutAlterarStatusAsync(Guid id, string statusExameId)
        {
            var jsonString = JsonConvert.SerializeObject(new StatusConsultaDTO { Id = statusExameId });
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await ApplicationState.HttpClient.PutAsync($"{ApiEndPoint}/alterar-status/{id}", content);
            return response;
        }

        public async Task<List<ExameDTO>> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-consulta/{consultaId}");
            return JsonToDTO<List<ExameDTO>>(response);
        }
    }
}
