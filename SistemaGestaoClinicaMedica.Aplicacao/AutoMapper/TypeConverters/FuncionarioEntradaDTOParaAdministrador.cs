using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class FuncionarioEntradaDTOParaAdministrador : ITypeConverter<FuncionarioEntradaDTO, Administrador>
    {
        public Administrador Convert(FuncionarioEntradaDTO source, Administrador destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var admin = new Administrador(funcionario);

            return admin;
        }
    }
}
