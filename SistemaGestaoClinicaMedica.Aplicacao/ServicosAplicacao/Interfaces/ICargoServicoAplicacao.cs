using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Cargo;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ICargoServicoAplicacao
    {
        IList<CargoSaidaDTO> ObterTudo();
    }
}
