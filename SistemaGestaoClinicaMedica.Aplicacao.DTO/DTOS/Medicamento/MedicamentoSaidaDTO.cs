using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento
{
    public class MedicamentoSaidaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeFabrica { get; set; }
        public string Tarja { get; set; }
        public string FabricanteNome { get; set; }
        public bool Ativo { get; set; }
    }
}
