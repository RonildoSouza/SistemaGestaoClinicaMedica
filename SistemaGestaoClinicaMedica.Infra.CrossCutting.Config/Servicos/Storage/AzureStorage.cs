using Azure.Storage.Blobs;
using System;
using System.IO;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Storage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly BlobContainerClient _blobContainerClient;

        public AzureStorage(BlobContainerClient blobContainerClient)
        {
            _blobContainerClient = blobContainerClient;
        }

        public Uri UploadDeArquivo(Stream stream, string blobName)
        {
            var blob = _blobContainerClient.GetBlobClient(blobName);
            blob.Upload(stream, true);

            return blob.Uri;
        }
    }
}
