﻿using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicamentoServico : ServicoBase<MedicamentoDTO, Guid>, IMedicamentoServico
    {
        protected override string EndPoint => "medicamentos";

        public MedicamentoServico(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<MedicamentoDTO>> GetPorNomeAsync(string nome)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-nome/{nome}");
            return JsonToDTO<List<MedicamentoDTO>>(response);
        }
    }
}
