using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class EspecialidadeServicoAplicacao : ServicoAplicacaoLeitura<EspecialidadeDTO, Guid, Especialidade>, IEspecialidadeServicoAplicacao
    {
        private readonly IEspecialidadeServico _especialidadeServico;

        public EspecialidadeServicoAplicacao(IMapper mapper, IEspecialidadeServico especialidadeServico) : base(mapper, especialidadeServico)
        {
            _especialidadeServico = especialidadeServico;
        }

        public IList<EspecialidadeDTO> ObterDisponiveis()
        {
            var entidades = _especialidadeServico.ObterDisponiveis();
            return _mapper.Map<List<EspecialidadeDTO>>(entidades);
        }

        public IList<EspecialidadeDTO> ObterTudo(bool comMedicos)
        {
            var entidades = _especialidadeServico.ObterTudoComFiltros(comMedicos);
            return _mapper.Map<List<EspecialidadeDTO>>(entidades);
        }
    }
}
