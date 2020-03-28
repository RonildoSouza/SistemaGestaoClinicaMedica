namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Documentos
{
    public interface IConstroiDocumento
    {
        string ConstroiTemplate<T>(T modelo);
    }
}
