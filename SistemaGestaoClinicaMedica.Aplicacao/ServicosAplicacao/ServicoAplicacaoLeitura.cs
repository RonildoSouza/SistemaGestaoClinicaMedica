using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ServicoAplicacaoLeitura<TEntidade, TSaida, TEntidadeId> : IServicoAplicacaoLeitura<TSaida, TEntidadeId>
         where TEntidade : IEntidade<TEntidadeId>
    {
        protected readonly IMapper _mapper;
        protected readonly IServicoBase<TEntidadeId, TEntidade> _servico;

        public ServicoAplicacaoLeitura(IMapper mapper, IServicoBase<TEntidadeId, TEntidade> servico)
        {
            _mapper = mapper;
            _servico = servico;
        }

        public virtual TSaida Obter(TEntidadeId id)
        {
            var entidade = _servico.Obter(id);
            return _mapper.Map<TSaida>(entidade);
        }

        public virtual IList<TSaida> ObterTudo()
        {
            var entidades = _servico.ObterTudo();
            return _mapper.Map<List<TSaida>>(entidades);
        }
    }
}
