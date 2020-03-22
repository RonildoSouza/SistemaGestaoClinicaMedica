using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ConsultasForm
    {
        private string PacienteNome { get; set; }
        private string EspecialidadeNome { get; set; }
        private string MedicoNome { get; set; }
        private string DataHora { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var consultaLocalStorage = await LocalStorage.ObterConsultaLocalStorageAsync();

            PacienteNome = consultaLocalStorage.Paciente.Nome;
            EspecialidadeNome = consultaLocalStorage.Especialidade.Nome;
            MedicoNome = $"{consultaLocalStorage.Medico.Nome} - CRM {consultaLocalStorage.Medico.CRM}";
            DataHora = consultaLocalStorage.Data.ToString("dddd, dd \\de MMMM, yyyy á\\s HH:mm");

            _dto.Data = consultaLocalStorage.Data;
            _dto.PacienteId = consultaLocalStorage.Paciente.Id;
            _dto.EspecialidadeId = consultaLocalStorage.Especialidade.Id;
            _dto.MedicoId = consultaLocalStorage.Medico.Id;
            _dto.StatusConsultaId = "Agendada";

            await base.OnParametersSetAsync();
        }
    }
}
