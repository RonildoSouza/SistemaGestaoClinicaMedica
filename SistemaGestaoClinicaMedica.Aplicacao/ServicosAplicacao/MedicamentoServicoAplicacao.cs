using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class MedicamentoServicoAplicacao : ServicoAplicacaoBase<MedicamentoDTO, Guid, Medicamento>, IMedicamentoServicoAplicacao
    {
        private readonly IMedicamentoServico _medicamentoServico;

        public MedicamentoServicoAplicacao(IMapper mapper, IMedicamentoServico medicamentoServico) : base(mapper, medicamentoServico)
        {
            _medicamentoServico = medicamentoServico;
        }

        public IList<MedicamentoDTO> ObterTudo(string busca, bool ativo)
        {
            var entidades = _medicamentoServico.ObterTudoComFiltros(busca, ativo);
            return _mapper.Map<List<MedicamentoDTO>>(entidades);
        }
    }
}
