using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Medicamento : IEntidade<Guid>
    {
        public Medicamento() { }

        public Medicamento(Guid id, string nome, string nomeFabrica, string tarja, bool ativo, Fabricante fabricante)
        {
            Id = id;
            Nome = nome;
            NomeFabrica = nomeFabrica;
            Tarja = tarja;
            Ativo = ativo;
            Fabricante = fabricante;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeFabrica { get; set; }
        public string Tarja { get; set; }
        public bool Ativo { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}