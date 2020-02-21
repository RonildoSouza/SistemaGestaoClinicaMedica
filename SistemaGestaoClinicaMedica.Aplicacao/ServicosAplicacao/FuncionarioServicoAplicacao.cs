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
        private readonly IFuncionarioServico _funcionarioServico;
        private readonly IAdministradorServico _administradorServico;
        private readonly IMedicoServico _medicoServico;
        private readonly IRecepcionistaServico _recepcionistaServico;
        private readonly ICargoServico _cargoServico;

        public FuncionarioServicoAplicacao(
            IFuncionarioServico funcionarioServico,
            IAdministradorServico administradorServico,
            IMedicoServico medicoServico,
            IRecepcionistaServico recepcionistaServico, 
            ICargoServico cargoServico)
        {
            _funcionarioServico = funcionarioServico;
            _administradorServico = administradorServico;
            _medicoServico = medicoServico;
            _recepcionistaServico = recepcionistaServico;
            _cargoServico = cargoServico;
        }

        public void Deletar(Guid id)
        {
            _funcionarioServico.Deletar(id);
        }

        public dynamic Obter(Guid id)
        {
            return _funcionarioServico.Obter(id);
        }

        public IList<dynamic> ObterTodos(bool ativo = true)
        {
            return _funcionarioServico.ObterTudoAtivoOuInativo(ativo).Cast<dynamic>().ToList();
        }

        public void Salvar(FuncionarioEntradaDTO funcionarioEntradaDTO)
        {
            var cargo = _cargoServico.Obter(funcionarioEntradaDTO.CargoId);

            switch (cargo.Id)
            {
                case "Administrador":
                    var admin = new Administrador();
                    _administradorServico.Salvar(admin);
                    break;
                case "Medico":
                    var medico = new Medico();
                    _medicoServico.Salvar(medico);
                    break;
                case "Recepcionista":
                    var recepcionista = new Recepcionista();
                    _recepcionistaServico.Salvar(recepcionista);
                    break;
            }
        }
    }
}
