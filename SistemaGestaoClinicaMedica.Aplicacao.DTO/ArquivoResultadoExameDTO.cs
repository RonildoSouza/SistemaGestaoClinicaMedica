using System.IO;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ArquivoResultadoExameDTO
    {
        public ArquivoResultadoExameDTO(string nomeArquivo, Stream streamArquivo)
        {
            NomeArquivo = nomeArquivo;
            StreamArquivo = streamArquivo;
        }

        public string NomeArquivo { get; set; }
        public Stream StreamArquivo { get; set; }
    }
}
