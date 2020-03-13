using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class FuncionarioEntradaDTOParaLaboratorio : ITypeConverter<FuncionarioEntradaDTO, Laboratorio>
    {
        public Laboratorio Convert(FuncionarioEntradaDTO source, Laboratorio destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var lab = new Laboratorio(funcionario, source.DaClinica);

            return lab;
        }
    }
}
