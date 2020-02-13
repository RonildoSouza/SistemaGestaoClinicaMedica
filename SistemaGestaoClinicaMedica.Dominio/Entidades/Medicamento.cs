﻿using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Medicamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeFabrica { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}