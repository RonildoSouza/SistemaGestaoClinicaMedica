using SistemaGestaoClinicaMedica.Aplicacao.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IServicoAplicacaoBase<TSaidaDTO, TEntradaDTO, TId> : IServicoAplicacaoLeitura<TSaidaDTO, TId>
        where TEntradaDTO : IEntradaDTO<TId>
    {
        TSaidaDTO Salvar(TEntradaDTO entradaDTO, TId id = default);
        void Deletar(TId id);
    }
}
