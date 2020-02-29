using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class EspecialidadeServicoAplicacao : IEspecialidadeServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IEspecialidadeServico _especialidadeServico;

        public EspecialidadeServicoAplicacao(IMapper mapper, IEspecialidadeServico especialidadeServico)
        {
            _mapper = mapper;
            _especialidadeServico = especialidadeServico;
        }

        public EspecialidadeSaidaDTO Obter(Guid id)
        {
            var entidade = _especialidadeServico.Obter(id);
            return _mapper.Map<EspecialidadeSaidaDTO>(entidade);
        }

        public IList<EspecialidadeSaidaDTO> ObterTudo(bool comMedicos = false)
        {
            var entidades = _especialidadeServico.ObterTudo(comMedicos).ToList();
            return _mapper.Map<List<EspecialidadeSaidaDTO>>(entidades);
        }
    }
}
