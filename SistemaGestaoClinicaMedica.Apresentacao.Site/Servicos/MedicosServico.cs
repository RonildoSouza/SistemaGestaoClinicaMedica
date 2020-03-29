﻿using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicosServico : ServicoBaseLeitura<MedicoDTO, Guid>, IMedicosServico
    {
        public MedicosServico(IConfiguration configuration) : base(configuration) { }

        public async Task<List<MedicoDTO>> GetPorEspecialidadeAsync(Guid especialidadeId)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-especialidade/{especialidadeId}");
            return JsonToDTO<List<MedicoDTO>>(response);
        }
    }
}