using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class FuncionarioDTOParaAdministrador : ITypeConverter<FuncionarioDTO, Administrador>
    {
        public Administrador Convert(FuncionarioDTO source, Administrador destination, ResolutionContext context)
        {
            var funcionario = context.Mapper.Map<Funcionario>(source);
            var admin = new Administrador(funcionario);

            return admin;
        }
    }
}
