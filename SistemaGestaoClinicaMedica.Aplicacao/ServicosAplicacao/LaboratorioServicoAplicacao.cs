using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class LaboratorioServicoAplicacao : ServicoAplicacaoBase<LaboratorioDTO, Guid, Laboratorio>, ILaboratorioServicoAplicacao
    {
        public LaboratorioServicoAplicacao(IMapper mapper, ILaboratorioServico laboratorioServico) : base(mapper, laboratorioServico)
        {
        }
    }
}
