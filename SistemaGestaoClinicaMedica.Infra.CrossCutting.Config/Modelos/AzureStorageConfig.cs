namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public sealed class AzureStorageConfig
    {
        public string ConnectionString { get; set; }
        public string Container { get; set; }
    }
}
