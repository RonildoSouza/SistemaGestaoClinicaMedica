using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class ConsultaServicoAplicacao : ServicoAplicacaoBase<ConsultaDTO, Guid, Consulta>, IConsultaServicoAplicacao
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultaServicoAplicacao(IMapper mapper, IConsultaServico consultaServico) : base(mapper, consultaServico)
        {
            _consultaServico = consultaServico;
        }

        public ConsultaDTO Obter(Guid id, bool comExames, bool comAtestados)
        {
            var entidade = _consultaServico.Obter(id, comExames, comAtestados);
            return _mapper.Map<ConsultaDTO>(entidade);
        }

        public IList<ConsultaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status)
        {
            List<Consulta> entidades;

            if (!string.IsNullOrEmpty(status))
            {
                Enum.TryParse(status, out EStatusConsulta eStatusConsulta);
                entidades = _consultaServico.ObterTudo(dataInicio, dataFim, busca, eStatusConsulta).ToList();
            }
            else
                entidades = _consultaServico.ObterTudo(dataInicio, dataFim, busca, null).ToList();

            return _mapper.Map<List<ConsultaDTO>>(entidades);
        }
    }
}
