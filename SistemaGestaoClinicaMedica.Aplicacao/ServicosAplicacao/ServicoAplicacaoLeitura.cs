using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ServicoAplicacaoLeitura<TEntidade, TSaida, TId> : IServicoAplicacaoLeitura<TSaida, TId>
         where TEntidade : IEntidade<TId>
    {
        protected readonly IMapper _mapper;
        protected readonly IServicoBase<TId, TEntidade> _servico;

        public ServicoAplicacaoLeitura(IMapper mapper, IServicoBase<TId, TEntidade> servico)
        {
            _mapper = mapper;
            _servico = servico;
        }

        public virtual TSaida Obter(TId id)
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
