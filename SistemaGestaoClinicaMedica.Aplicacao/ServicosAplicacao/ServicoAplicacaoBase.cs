using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ServicoAplicacaoBase<TDTO, TEntidadeId, TEntidade> : ServicoAplicacaoLeitura<TDTO, TEntidadeId, TEntidade>, IServicoAplicacaoBase<TDTO, TEntidadeId>
         where TEntidade : IEntidade<TEntidadeId>
         where TDTO : IDTO<TEntidadeId>
    {
        public ServicoAplicacaoBase(IMapper mapper, IServicoBase<TEntidadeId, TEntidade> servico) : base(mapper, servico)
        {
        }

        public virtual void Deletar(TEntidadeId id)
        {
            _servico.Deletar(id);
        }

        public virtual TDTO Salvar(TDTO entradaDTO, TEntidadeId id = default)
        {
            entradaDTO.Id = id;
            var entidade = _mapper.Map<TEntidade>(entradaDTO);
            entidade = _servico.Salvar(entidade);

            return _mapper.Map<TDTO>(entidade);
        }
    }
}
