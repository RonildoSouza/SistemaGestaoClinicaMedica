using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class HorarioDeTrabalhoDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public int DiaDaSemana { get; set; }
        public string Inicio { get; set; }
        public string InicioIntervalo { get; set; }
        public string FimIntervalo { get; set; }
        public string Fim { get; set; }
        public bool Ativo { get; set; }
    }
}
