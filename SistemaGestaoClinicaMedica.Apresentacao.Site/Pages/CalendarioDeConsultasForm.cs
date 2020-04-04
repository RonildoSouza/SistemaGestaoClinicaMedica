using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Dominio.Documentos;
using SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class CalendarioDeConsultasForm
    {
        private string _pacienteNome;
        private string _especialidadeNome;
        private string _medicoNome;
        private string _dataHora;

        [Inject] private IConstroiDocumento ConstroiDocumento { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var consultaLocalStorage = await LocalStorage.ObterConsultaLocalStorageAsync();

            _pacienteNome = consultaLocalStorage.Paciente.Nome;
            _especialidadeNome = consultaLocalStorage.Especialidade.Nome;
            _medicoNome = $"{consultaLocalStorage.Medico.Nome} - CRM {consultaLocalStorage.Medico.CRM}";
            _dataHora = consultaLocalStorage.Data.ToDateAndTime();

            _dto.Data = consultaLocalStorage.Data;
            _dto.PacienteId = consultaLocalStorage.Paciente.Id;
            _dto.EspecialidadeId = consultaLocalStorage.Especialidade.Id;
            _dto.MedicoId = consultaLocalStorage.Medico.Id;
            _dto.StatusConsultaId = StatusConsultaConst.Agendada;
            _dto.Observacao = ConstroiDocumento.ConstroiTemplate<ConsultaTemplate>();

            await base.OnParametersSetAsync();
        }
    }
}
