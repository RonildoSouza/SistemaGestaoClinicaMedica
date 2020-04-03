using System;
using System.IO;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Storage
{
    public interface IAzureStorage
    {
        Uri UploadDeArquivo(Stream stream, string blobName);
    }
}
