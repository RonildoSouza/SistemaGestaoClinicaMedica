using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class FuncionarioServicoAplicacao : IFuncionarioServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioServico _funcionarioServico;
        private readonly IAdministradorServico _administradorServico;
        private readonly IMedicoServico _medicoServico;
        private readonly IRecepcionistaServico _recepcionistaServico;
        private readonly ILaboratorioServico _laboratorioServico;
        private readonly IMedicoEspecialidadeServico _medicoEspecialidadeServico;

        public FuncionarioServicoAplicacao(
            IMapper mapper,
            IFuncionarioServico funcionarioServico,
            IAdministradorServico administradorServico,
            IMedicoServico medicoServico,
            IRecepcionistaServico recepcionistaServico,
            ILaboratorioServico laboratorioServico,
            IMedicoEspecialidadeServico medicoEspecialidadeServico)
        {
            _mapper = mapper;
            _funcionarioServico = funcionarioServico;
            _administradorServico = administradorServico;
            _medicoServico = medicoServico;
            _recepcionistaServico = recepcionistaServico;
            _laboratorioServico = laboratorioServico;
            _medicoEspecialidadeServico = medicoEspecialidadeServico;
        }

        public void Deletar(Guid id)
        {
            _funcionarioServico.Deletar(id);
        }

        public FuncionarioSaidaDTO Obter(Guid id)
        {
            var funcionarioEntidade = _funcionarioServico.Obter(id);

            return _mapper.Map<FuncionarioSaidaDTO>(funcionarioEntidade);
        }

        public IList<FuncionarioSaidaDTO> ObterTodos(bool ativo = true)
        {
            var listaFuncionarioEntidade = _funcionarioServico.ObterTudoAtivoOuInativo(ativo).ToList();

            return _mapper.Map<List<FuncionarioSaidaDTO>>(listaFuncionarioEntidade);
        }

        public FuncionarioSaidaDTO Salvar(FuncionarioEntradaDTO funcionarioEntradaDTO)
        {
            FuncionarioSaidaDTO funcionarioSaidaDTO = null;

            switch (funcionarioEntradaDTO.CargoId)
            {
                case "Administrador":
                    var admin = _mapper.Map<Administrador>(funcionarioEntradaDTO);
                    admin = _administradorServico.Salvar(admin);
                    funcionarioSaidaDTO = _mapper.Map<FuncionarioSaidaDTO>(admin.Funcionario);
                    break;
                case "Medico":
                    var medico = _mapper.Map<Medico>(funcionarioEntradaDTO);
                    medico = _medicoServico.Salvar(medico);

                    _medicoEspecialidadeServico.Salvar(
                        new MedicoEspecialidade
                        {
                            MedicoId = medico.Id,
                            EspecialidadeId = Guid.Parse("6F3BF373-F184-4641-9CA1-8500CBB27B7E")
                        });

                    funcionarioSaidaDTO = _mapper.Map<FuncionarioSaidaDTO>(medico.Funcionario);
                    break;
                case "Recepcionista":
                    var recepcionista = _mapper.Map<Recepcionista>(funcionarioEntradaDTO);
                    recepcionista = _recepcionistaServico.Salvar(recepcionista);
                    funcionarioSaidaDTO = _mapper.Map<FuncionarioSaidaDTO>(recepcionista.Funcionario);
                    break;
                case "Laboratorio":
                    var lab = _mapper.Map<Laboratorio>(funcionarioEntradaDTO);
                    lab = _laboratorioServico.Salvar(lab);
                    funcionarioSaidaDTO = _mapper.Map<FuncionarioSaidaDTO>(lab.Funcionario);
                    break;
            }

            return funcionarioSaidaDTO;
        }
    }
}
