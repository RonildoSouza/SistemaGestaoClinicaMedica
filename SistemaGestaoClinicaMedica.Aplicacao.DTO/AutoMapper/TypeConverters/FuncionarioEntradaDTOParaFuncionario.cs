using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class FuncionarioEntradaDTOParaFuncionario : ITypeConverter<FuncionarioEntradaDTO, Funcionario>
    {
        private readonly ICargoServico _cargoServico;

        public FuncionarioEntradaDTOParaFuncionario(ICargoServico cargoServico)
        {
            _cargoServico = cargoServico;
        }

        public Funcionario Convert(FuncionarioEntradaDTO source, Funcionario destination, ResolutionContext context)
        {
            var cargoEntidade = _cargoServico.Obter(source.CargoId);

            var funcionarioEntidade = new Funcionario(
                source.Id,
                source.Nome,
                source.Email,
                source.Telefone,
                source.Senha,
                cargoEntidade,
                source.Ativo);

            return funcionarioEntidade;
        }
    }
}
