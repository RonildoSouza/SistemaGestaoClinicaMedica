using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class FuncionarioServicoAplicacao : ServicoAplicacaoBase<Funcionario, FuncionarioSaidaDTO, FuncionarioEntradaDTO, Guid>, IFuncionarioServicoAplicacao
    {
        private readonly IFuncionarioServico _funcionarioServico;
        private readonly IAdministradorServico _administradorServico;
        private readonly IMedicoServico _medicoServico;
        private readonly IRecepcionistaServico _recepcionistaServico;
        private readonly ILaboratorioServico _laboratorioServico;

        public FuncionarioServicoAplicacao(
            IMapper mapper,
            IFuncionarioServico funcionarioServico,
            IAdministradorServico administradorServico,
            IMedicoServico medicoServico,
            IRecepcionistaServico recepcionistaServico,
            ILaboratorioServico laboratorioServico) : base(mapper, funcionarioServico)
        {
            _funcionarioServico = funcionarioServico;
            _administradorServico = administradorServico;
            _medicoServico = medicoServico;
            _recepcionistaServico = recepcionistaServico;
            _laboratorioServico = laboratorioServico;
        }

        public IList<FuncionarioSaidaDTO> ObterTudo(bool ativo)
        {
            var entidades = _funcionarioServico.ObterTudo(ativo);
            return _mapper.Map<List<FuncionarioSaidaDTO>>(entidades);
        }

        public override FuncionarioSaidaDTO Salvar(FuncionarioEntradaDTO funcionarioEntradaDTO, Guid id = default)
        {
            funcionarioEntradaDTO.Id = id;

            switch (funcionarioEntradaDTO.CargoId)
            {
                case "Administrador":
                    var admin = _mapper.Map<Administrador>(funcionarioEntradaDTO);
                    admin = _administradorServico.Salvar(admin);
                    return _mapper.Map<FuncionarioSaidaDTO>(admin.Funcionario);
                case "Medico":
                    var medico = _mapper.Map<Medico>(funcionarioEntradaDTO);
                    medico = _medicoServico.Salvar(medico);
                    return _mapper.Map<FuncionarioSaidaDTO>(medico.Funcionario);
                case "Recepcionista":
                    var recepcionista = _mapper.Map<Recepcionista>(funcionarioEntradaDTO);
                    recepcionista = _recepcionistaServico.Salvar(recepcionista);
                    return _mapper.Map<FuncionarioSaidaDTO>(recepcionista.Funcionario);
                case "Laboratorio":
                    var lab = _mapper.Map<Laboratorio>(funcionarioEntradaDTO);
                    lab = _laboratorioServico.Salvar(lab);
                    return _mapper.Map<FuncionarioSaidaDTO>(lab.Funcionario);
                default:
                    return null;
            }
        }
    }
}
