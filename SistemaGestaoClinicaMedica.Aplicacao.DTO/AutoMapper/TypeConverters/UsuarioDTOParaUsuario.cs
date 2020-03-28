using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class UsuarioDTOParaUsuario : ITypeConverter<UsuarioDTO, Usuario>
    {
        private readonly ICargoServico _cargoServico;

        public UsuarioDTOParaUsuario(ICargoServico cargoServico)
        {
            _cargoServico = cargoServico;
        }

        public Usuario Convert(UsuarioDTO source, Usuario destination, ResolutionContext context)
        {
            var cargo = _cargoServico.Obter(source.Cargo.Id);

            var usuario = new Usuario(
                source.Id,
                source.Nome,
                source.Email,
                source.Telefone,
                source.Senha,
                cargo,
                source.Ativo);

            return usuario;
        }
    }
}
