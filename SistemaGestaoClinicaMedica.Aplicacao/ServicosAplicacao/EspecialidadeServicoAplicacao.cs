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

        public IDictionary<DateTime, bool> ObterDatasComHorariosDisponiveis(Guid especialidadeId, DateTime dataInicio, DateTime dataFim, Guid? medicoId = null)
        {
            return _especialidadeServico.ObterDatasComHorariosDisponiveis(especialidadeId, dataInicio, dataFim, medicoId);
        }

        public IList<EspecialidadeDTO> ObterDisponiveis()
        {
            var entidades = _especialidadeServico.ObterDisponiveis();
            return _mapper.Map<List<EspecialidadeDTO>>(entidades);
        }

        public IList<TimeSpan> ObterHorariosDisponiveis(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId = null)
        {
            return _especialidadeServico.ObterHorariosDisponiveis(especialidadeId, dataDaConsulta, medicoId);
        }

        public IList<EspecialidadeDTO> ObterTudo(bool comMedicos)
        {
            var entidades = _especialidadeServico.ObterTudoComFiltros(comMedicos);
            return _mapper.Map<List<EspecialidadeDTO>>(entidades);
        }
    }
}
