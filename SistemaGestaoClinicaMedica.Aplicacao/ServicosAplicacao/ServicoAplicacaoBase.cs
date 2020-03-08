using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ServicoAplicacaoBase<TEntidade, TSaida, TEntradaDTO, TEntidadeId> : ServicoAplicacaoLeitura<TEntidade, TSaida, TEntidadeId>, IServicoAplicacaoBase<TSaida, TEntradaDTO, TEntidadeId>
         where TEntidade : IEntidade<TEntidadeId>
         where TEntradaDTO : IEntradaDTO<TEntidadeId>
    {
        public ServicoAplicacaoBase(IMapper mapper, IServicoBase<TEntidadeId, TEntidade> servico) : base(mapper, servico)
        {
        }

        public virtual void Deletar(TEntidadeId id)
        {
            _servico.Deletar(id);
        }

        public virtual TSaida Salvar(TEntradaDTO entradaDTO, TEntidadeId id = default)
        {
            entradaDTO.Id = id;
            var entidade = _mapper.Map<TEntidade>(entradaDTO);
            entidade = _servico.Salvar(entidade);

            return _mapper.Map<TSaida>(entidade);
        }
    }
}
