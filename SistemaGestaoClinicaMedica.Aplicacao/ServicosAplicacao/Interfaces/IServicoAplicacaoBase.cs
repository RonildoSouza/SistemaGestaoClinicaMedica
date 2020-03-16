using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IServicoAplicacaoBase<TDTO, TEntidadeId> : IServicoAplicacaoLeitura<TDTO, TEntidadeId>
        where TDTO : IDTO<TEntidadeId>
    {
        TDTO Salvar(TDTO entradaDTO, TEntidadeId id = default);
        void Deletar(TEntidadeId id);
    }
}
