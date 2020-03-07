using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class PacienteServicoAplicacao : ServicoAplicacaoBase<Paciente, PacienteSaidaDTO, PacienteEntradaDTO, Guid>, IPacienteServicoAplicacao
    {
        private readonly IPacienteServico _pacienteServico;

        public PacienteServicoAplicacao(IMapper mapper, IPacienteServico pacienteServico) : base(mapper, pacienteServico)
        {
            _pacienteServico = pacienteServico;
        }

        public IList<PacienteSaidaDTO> ObterTudo(string busca, bool ativo)
        {
            var entidades = _pacienteServico.ObterTudo(busca, ativo);
            return _mapper.Map<List<PacienteSaidaDTO>>(entidades);
        }
    }
}
