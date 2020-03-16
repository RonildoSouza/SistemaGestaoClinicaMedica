using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class FuncionarioDTOParaFuncionario : ITypeConverter<FuncionarioDTO, Funcionario>
    {
        private readonly ICargoServico _cargoServico;

        public FuncionarioDTOParaFuncionario(ICargoServico cargoServico)
        {
            _cargoServico = cargoServico;
        }

        public Funcionario Convert(FuncionarioDTO source, Funcionario destination, ResolutionContext context)
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
