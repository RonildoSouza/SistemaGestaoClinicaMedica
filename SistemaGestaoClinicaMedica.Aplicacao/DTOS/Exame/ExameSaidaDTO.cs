namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame
{
    public class ExameSaidaDTO
    {
        public TipoDeExameSaidaDTO TipoDeExame { get; set; }
        public string Observacao { get; set; }
        public string StatusExame { get; set; }
    }
}
