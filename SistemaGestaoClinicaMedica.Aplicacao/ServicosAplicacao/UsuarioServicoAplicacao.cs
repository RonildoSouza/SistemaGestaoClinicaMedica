using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class UsuarioServicoAplicacao : ServicoAplicacaoBase<UsuarioDTO, Guid, Usuario>, IUsuarioServicoAplicacao
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioServicoAplicacao(IMapper mapper, IUsuarioServico usuarioServico) : base(mapper, usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public IList<UsuarioDTO> ObterTudo(bool ativo)
        {
            var entidades = _usuarioServico.ObterTudoComFiltros(ativo);
            return _mapper.Map<List<UsuarioDTO>>(entidades);
        }
    }
}
