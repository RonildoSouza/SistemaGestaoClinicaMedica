using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class RecepcionistaServico : ServicoBase<Guid, Recepcionista>, IRecepcionistaServico
    {
        public RecepcionistaServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
