using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class AdministradorServicoAplicacao : ServicoAplicacaoBase<AdministradorDTO, Guid, Administrador>, IAdministradorServicoAplicacao
    {
        public AdministradorServicoAplicacao(IMapper mapper, IAdministradorServico administradorServico) : base(mapper, administradorServico)
        {
        }
    }
}
