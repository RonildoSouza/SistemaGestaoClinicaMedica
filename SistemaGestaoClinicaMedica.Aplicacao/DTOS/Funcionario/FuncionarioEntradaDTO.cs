﻿using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario
{
    public class FuncionarioEntradaDTO
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string CargoId { get; set; }
        public string CRM { get; set; }
    }
}
