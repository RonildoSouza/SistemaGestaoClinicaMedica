﻿namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class StatusExame : IEntidade<string>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}