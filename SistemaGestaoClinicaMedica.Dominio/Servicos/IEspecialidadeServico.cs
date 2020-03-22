using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IEspecialidadeServico : IServicoBase<Guid, Especialidade>
    {
        IList<Especialidade> ObterDisponiveis();
        IList<Especialidade> ObterTudoComFiltros(bool comMedicos);
        IList<TimeSpan> ObterHorariosDisponiveis(Guid especialidadeId, DateTime data, Guid? medicoId = null);
    }
}
