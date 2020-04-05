using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class UsuarioDTOParaUsuario : ITypeConverter<UsuarioDTO, Usuario>
    {
        private readonly ICargoServico _cargoServico;
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioDTOParaUsuario(ICargoServico cargoServico, IUsuarioServico usuarioServico)
        {
            _cargoServico = cargoServico;
            _usuarioServico = usuarioServico;
        }

        public Usuario Convert(UsuarioDTO source, Usuario destination, ResolutionContext context)
        {
            var cargo = _cargoServico.Obter(source.Cargo.Id);

            //var usr = _usuarioServico.Obter(source.Id, true);
            //if (source.Id != Guid.Empty && usr.Senha == source.Senha)
            //    source.Senha = usr.Senha;

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
