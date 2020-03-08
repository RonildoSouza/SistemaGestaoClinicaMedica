using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ConsultaServicoAplicacao : ServicoAplicacaoBase<Consulta, ConsultaSaidaDTO, ConsultaEntradaDTO, Guid>, IConsultaServicoAplicacao
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultaServicoAplicacao(IMapper mapper, IConsultaServico consultaServico) : base(mapper, consultaServico)
        {
            _consultaServico = consultaServico;
        }

        public IList<ConsultaSaidaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status)
        {
            List<Consulta> entidades;

            if (!string.IsNullOrEmpty(status))
            {
                Enum.TryParse(status, out EStatusConsulta eStatusConsulta);
                entidades = _consultaServico.ObterTudo(dataInicio, dataFim, busca, eStatusConsulta).ToList();
            }
            else
                entidades = _consultaServico.ObterTudo(dataInicio, dataFim, busca, null).ToList();

            return _mapper.Map<List<ConsultaSaidaDTO>>(entidades);
        }
    }
}
