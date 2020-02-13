﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }
    }
}
