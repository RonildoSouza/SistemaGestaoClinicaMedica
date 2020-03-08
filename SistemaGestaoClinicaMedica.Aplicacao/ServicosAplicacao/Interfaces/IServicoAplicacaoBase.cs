using SistemaGestaoClinicaMedica.Aplicacao.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IServicoAplicacaoBase<TSaidaDTO, TEntradaDTO, TEntidadeId> : IServicoAplicacaoLeitura<TSaidaDTO, TEntidadeId>
        where TEntradaDTO : IEntradaDTO<TEntidadeId>
    {
        TSaidaDTO Salvar(TEntradaDTO entradaDTO, TEntidadeId id = default);
        void Deletar(TEntidadeId id);
    }
}
