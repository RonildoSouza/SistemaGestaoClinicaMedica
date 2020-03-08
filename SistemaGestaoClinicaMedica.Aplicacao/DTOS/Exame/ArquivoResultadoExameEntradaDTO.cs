using System.IO;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame
{
    public class ArquivoResultadoExameEntradaDTO
    {
        public ArquivoResultadoExameEntradaDTO(string nomeArquivo, Stream streamArquivo)
        {
            NomeArquivo = nomeArquivo;
            StreamArquivo = streamArquivo;
        }

        public string NomeArquivo { get; set; }
        public Stream StreamArquivo { get; set; }
    }
}
