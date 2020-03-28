using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class AdministradorDTOParaAdministrador : ITypeConverter<AdministradorDTO, Administrador>
    {
        private readonly IAdministradorServico _administradorServico;

        public AdministradorDTOParaAdministrador(IAdministradorServico administradorServico)
        {
            _administradorServico = administradorServico;
        }

        public Administrador Convert(AdministradorDTO source, Administrador destination, ResolutionContext context)
        {
            source.Cargo.Id = "Administrador";

            var usuario = context.Mapper.Map<Usuario>(source);
            var administrator = new Administrador(usuario)
            {
                // Recupera id da tabela de relacionamento
                Id = _administradorServico.Obter(usuario.Id, true)?.Id ?? Guid.Empty
            };

            return administrator;
        }
    }
}
