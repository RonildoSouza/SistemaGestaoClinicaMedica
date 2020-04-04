using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System;

namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public abstract class AtestadoTemplateBase
    {
        protected readonly DateTime _dataAtual = DateTime.Now;

        protected AtestadoTemplateBase(string tipoAtestadoNome, string pacienteNome, string pacienteCPF, string medicoNome, string medicoCRM)
        {
            TipoAtestadoNome = tipoAtestadoNome.ToUpper();
            PacienteNome = pacienteNome.ToUpper();
            PacienteCPF = pacienteCPF.FormataCPF();
            MedicoNome = medicoNome.ToUpper();
            MedicoCRM = medicoCRM.ToUpper();
        }

        public string TipoAtestadoNome { get; set; }
        public string PacienteNome { get; set; }
        public string PacienteCPF { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }

        public string DataAtual => _dataAtual.ToString("dd/MM/yyyy");
        public string HoraAtual => _dataAtual.ToString("HH\\:mm");
        public string Localidade => $"Belo Horizonte - MG, {_dataAtual.ToString("dddd, dd \\de MMMM, yyyy")}.";
    }
}
