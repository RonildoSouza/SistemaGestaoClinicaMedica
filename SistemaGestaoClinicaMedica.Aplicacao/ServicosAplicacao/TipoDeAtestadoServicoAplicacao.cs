using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class TipoDeAtestadoServicoAplicacao : ServicoAplicacaoLeitura<TipoDeAtestado, TipoDeAtestadoSaidaDTO, ETipoDeAtestado>, ITipoDeAtestadoServicoAplicacao
    {
        public TipoDeAtestadoServicoAplicacao(IMapper mapper, ITipoDeAtestadoServico tipoDeAtestadoServico) : base(mapper, tipoDeAtestadoServico)
        {
        }
    }
}
