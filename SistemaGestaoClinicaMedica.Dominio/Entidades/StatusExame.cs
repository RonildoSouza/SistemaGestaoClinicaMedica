namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class StatusExame : IEntidade<EStatusExame>
    {
        public EStatusExame Id { get; set; }
        public string Nome { get; set; }
    }

    public enum EStatusExame
    {
        Pendente,
        EmAnaliseLaboratorial,
        Concluido,
    }
}