﻿using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class StatusConsultasServico : ServicoBaseLeitura<StatusConsultaDTO, string>, IStatusConsultasServico
    {
        public StatusConsultasServico(IConfiguration configuration) : base(configuration) { }
    }
}