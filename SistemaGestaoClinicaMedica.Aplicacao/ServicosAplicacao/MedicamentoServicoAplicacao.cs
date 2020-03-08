﻿using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class MedicamentoServicoAplicacao : ServicoAplicacaoBase<Medicamento, MedicamentoSaidaDTO, MedicamentoEntradaDTO, Guid>, IMedicamentoServicoAplicacao
    {
        private readonly IMedicamentoServico _medicamentoServico;

        public MedicamentoServicoAplicacao(IMapper mapper, IMedicamentoServico medicamentoServico) : base(mapper, medicamentoServico)
        {
            _medicamentoServico = medicamentoServico;
        }

        public IList<MedicamentoSaidaDTO> ObterTudo(string busca, bool ativo)
        {
            var entidades = _medicamentoServico.ObterTudo(busca, ativo);
            return _mapper.Map<List<MedicamentoSaidaDTO>>(entidades);
        }
    }
}