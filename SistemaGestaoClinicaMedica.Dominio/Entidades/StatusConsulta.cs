namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class StatusConsulta : IEntidade<EStatusConsulta>
    {
        public EStatusConsulta Id { get; set; }
        public string Nome { get; set; }
    }

    public enum EStatusConsulta
    {
        Agendada,
        AguardandoRetorno,
        Cancelada,
        Concluida,
    }
}