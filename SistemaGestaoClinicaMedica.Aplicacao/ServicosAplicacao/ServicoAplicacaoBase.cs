using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ServicoAplicacaoBase<TEntidade, TSaida, TEntradaDTO, TId> : ServicoAplicacaoLeitura<TEntidade, TSaida, TId>, IServicoAplicacaoBase<TSaida, TEntradaDTO, TId>
         where TEntidade : IEntidade<TId>
         where TEntradaDTO : IEntradaDTO<TId>
    {
        public ServicoAplicacaoBase(IMapper mapper, IServicoBase<TId, TEntidade> servico) : base(mapper, servico)
        {
        }

        public virtual void Deletar(TId id)
        {
            _servico.Deletar(id);
        }

        public virtual TSaida Salvar(TEntradaDTO entradaDTO, TId id = default)
        {
            entradaDTO.Id = id;
            var entidade = _mapper.Map<TEntidade>(entradaDTO);
            entidade = _servico.Salvar(entidade);

            return _mapper.Map<TSaida>(entidade);
        }
    }
}
