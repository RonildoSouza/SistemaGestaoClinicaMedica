namespace SistemaGestaoClinicaMedica.Dominio.Documentos
{
    public interface IConstroiDocumento
    {
        string ConstroiTemplate<T>(T modelo);
        string ConstroiTemplate<T>();
    }
}
