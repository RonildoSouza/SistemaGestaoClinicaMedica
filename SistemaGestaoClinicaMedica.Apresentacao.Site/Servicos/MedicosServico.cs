using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicosServico : ServicoBase<MedicoDTO, Guid>, IMedicosServico
    {
        public MedicosServico(IConfiguration configuration, ILocalStorageService localStorage) : base(configuration, localStorage) { }

        public async Task<List<MedicoDTO>> GetPorEspecialidadeAsync(Guid especialidadeId)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-especialidade/{especialidadeId}");
            return JsonToDTO<List<MedicoDTO>>(response);
        }
    }
}
