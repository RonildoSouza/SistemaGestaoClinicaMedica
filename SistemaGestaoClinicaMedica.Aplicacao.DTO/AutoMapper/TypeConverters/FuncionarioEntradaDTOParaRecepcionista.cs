using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class FuncionarioEntradaDTOParaRecepcionista : ITypeConverter<FuncionarioEntradaDTO, Recepcionista>
    {
        public Recepcionista Convert(FuncionarioEntradaDTO source, Recepcionista destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var recepcionista = new Recepcionista(funcionario);

            return recepcionista;
        }
    }
}
