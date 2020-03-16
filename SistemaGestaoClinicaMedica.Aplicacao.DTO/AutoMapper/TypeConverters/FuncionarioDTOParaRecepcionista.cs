using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class FuncionarioDTOParaRecepcionista : ITypeConverter<FuncionarioDTO, Recepcionista>
    {
        public Recepcionista Convert(FuncionarioDTO source, Recepcionista destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var recepcionista = new Recepcionista(funcionario);

            return recepcionista;
        }
    }
}
