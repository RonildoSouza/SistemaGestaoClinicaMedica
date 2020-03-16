using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ServicoAplicacaoLeitura<TDTO, TEntidadeId, TEntidade> : IServicoAplicacaoLeitura<TDTO, TEntidadeId>
         where TEntidade : IEntidade<TEntidadeId>
    {
        protected readonly IMapper _mapper;
        protected readonly IServicoBase<TEntidadeId, TEntidade> _servico;

        public ServicoAplicacaoLeitura(IMapper mapper, IServicoBase<TEntidadeId, TEntidade> servico)
        {
            _mapper = mapper;
            _servico = servico;
        }

        public virtual TDTO Obter(TEntidadeId id)
        {
            var entidade = _servico.Obter(id);
            return _mapper.Map<TDTO>(entidade);
        }

        public virtual IList<TDTO> ObterTudo()
        {
            var entidades = _servico.ObterTudo();
            return _mapper.Map<List<TDTO>>(entidades);
        }
    }
}
