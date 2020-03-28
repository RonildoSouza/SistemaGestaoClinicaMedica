using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class RecepcionistaServicoAplicacao : ServicoAplicacaoBase<RecepcionistaDTO, Guid, Recepcionista>, IRecepcionistaServicoAplicacao
    {
        public RecepcionistaServicoAplicacao(IMapper mapper, IRecepcionistaServico recepcionistaServico) : base(mapper, recepcionistaServico)
        {
        }
    }
}
