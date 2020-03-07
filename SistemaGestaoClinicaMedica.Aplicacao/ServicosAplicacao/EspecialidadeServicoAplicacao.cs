using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class EspecialidadeServicoAplicacao : ServicoAplicacaoLeitura<Especialidade, EspecialidadeSaidaDTO, Guid>, IEspecialidadeServicoAplicacao
    {
        private readonly IEspecialidadeServico _especialidadeServico;

        public EspecialidadeServicoAplicacao(IMapper mapper, IEspecialidadeServico especialidadeServico) : base(mapper, especialidadeServico)
        {
            _especialidadeServico = especialidadeServico;
        }

        public IList<EspecialidadeSaidaDTO> ObterTudo(bool comMedicos)
        {
            var entidades = _especialidadeServico.ObterTudo(comMedicos);
            return _mapper.Map<List<EspecialidadeSaidaDTO>>(entidades);
        }
    }
}
