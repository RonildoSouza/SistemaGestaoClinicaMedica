namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico
{
    public class HorarioDeTrabalhoEntradaDTO
    {
        public int DiaDaSemana { get; set; }
        public string Inicio { get; set; }
        public string InicioAlmoco { get; set; }
        public string FimAlmoco { get; set; }
        public string Fim { get; set; }
    }
}
