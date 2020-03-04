using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class MedicamentoServicoAplicacao : IMedicamentoServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IMedicamentoServico _medicamentoServico;

        public MedicamentoServicoAplicacao(IMapper mapper, IMedicamentoServico medicamentoServico)
        {
            _mapper = mapper;
            _medicamentoServico = medicamentoServico;
        }

        public void Deletar(Guid id)
        {
            _medicamentoServico.Deletar(id);
        }

        public MedicamentoSaidaDTO Obter(Guid id)
        {
            var entidade = _medicamentoServico.Obter(id);
            return _mapper.Map<MedicamentoSaidaDTO>(entidade);
        }

        public IList<MedicamentoSaidaDTO> ObterTudo(string nome, bool ativo = true)
        {
            var entidades = _medicamentoServico.ObterTudo(nome?.ToUpper(), ativo);
            return _mapper.Map<List<MedicamentoSaidaDTO>>(entidades);
        }

        public MedicamentoSaidaDTO Salvar(MedicamentoEntradaDTO medicamentoEntradaDTO, Guid id = default)
        {
            medicamentoEntradaDTO.Id = id;
            var entidade = _mapper.Map<Medicamento>(medicamentoEntradaDTO);
            entidade = _medicamentoServico.Salvar(entidade);

            return _mapper.Map<MedicamentoSaidaDTO>(entidade);
        }
    }
}
