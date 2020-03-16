using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class PacienteServicoAplicacao : ServicoAplicacaoBase<PacienteDTO, Guid, Paciente>, IPacienteServicoAplicacao
    {
        private readonly IPacienteServico _pacienteServico;

        public PacienteServicoAplicacao(IMapper mapper, IPacienteServico pacienteServico) : base(mapper, pacienteServico)
        {
            _pacienteServico = pacienteServico;
        }

        public IList<PacienteDTO> ObterTudo(string busca, bool ativo)
        {
            var entidades = _pacienteServico.ObterTudo(busca, ativo);
            return _mapper.Map<List<PacienteDTO>>(entidades);
        }
    }
}
