using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class FuncionarioDTOParaLaboratorio : ITypeConverter<FuncionarioDTO, Laboratorio>
    {
        public Laboratorio Convert(FuncionarioDTO source, Laboratorio destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var lab = new Laboratorio(funcionario, source.DaClinica);

            return lab;
        }
    }
}
