using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
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

        public void AlterarStatus(Guid id, StatusConsultaDTO statusConsulta)
        {
            var eStatusConsulta = statusConsulta.Id.StringParaStatusConsulta();
            _consultaServico.AlterarStatus(id, eStatusConsulta);
        }

        public ConsultaDTO Obter(Guid id, bool comExames, bool comAtestados)
        {
            var entidade = _consultaServico.ObterComFiltros(id, comExames, comAtestados);
            return _mapper.Map<ConsultaDTO>(entidade);
        }

        public ConsultaDTO ObterPorCodigo(string codigo)
        {
            var entidade = _consultaServico.ObterPorCodigo(codigo);
            return _mapper.Map<ConsultaDTO>(entidade);
        }

        public IList<ConsultaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null)
        {
            List<Consulta> entidades;

            if (!string.IsNullOrEmpty(status))
            {
                var listaEStatusConsulta = status.StringParaListaDeStatusConsulta();
                entidades = _consultaServico.ObterTudoComFiltros(dataInicio, dataFim, busca, listaEStatusConsulta, medicoId).ToList();
            }
            else
                entidades = _consultaServico.ObterTudoComFiltros(dataInicio, dataFim, busca, null, medicoId).ToList();

            return _mapper.Map<List<ConsultaDTO>>(entidades);
        }
    }
}
