using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IExameServico : IServicoBase<ExameDTO, Guid>
    {
        Task<ExameDTO> GetPorCodigoAsync(string codigo);
        Task<Uri> UploadResultado(Guid id, Stream stream, string arquivoNome);
        Task<HttpResponseMessage> PutAlterarStatusAsync(Guid id, string statusExameId);
        Task<List<ExameDTO>> GetPorConsultaAsync(Guid consultaId);
    }
}
