using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class TipoDeAtestadoServicoAplicacao : ServicoAplicacaoLeitura<TipoDeAtestadoDTO, ETipoDeAtestado, TipoDeAtestado>, ITipoDeAtestadoServicoAplicacao
    {
        public TipoDeAtestadoServicoAplicacao(IMapper mapper, ITipoDeAtestadoServico tipoDeAtestadoServico) : base(mapper, tipoDeAtestadoServico)
        {
        }
    }
}
