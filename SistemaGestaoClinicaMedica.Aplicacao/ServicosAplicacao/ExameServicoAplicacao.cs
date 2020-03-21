using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class ExameServicoAplicacao : ServicoAplicacaoBase<ExameDTO, Guid, Exame>, IExameServicoAplicacao
    {
        private readonly IExameServico _exameServico;

        public ExameServicoAplicacao(IMapper mapper, IExameServico exameServico) : base(mapper, exameServico)
        {
            _exameServico = exameServico;
        }

        public ExameDTO Obter(string codigo)
        {
            var entidade = _exameServico.ObterPorCodigo(codigo);
            return _mapper.Map<ExameDTO>(entidade);
        }

        public void UploadResultado(Guid id, ArquivoResultadoExameDTO arquivoDTO)
        {
            //TODO: Adicionar package para armazenar os arquivos no Azure Storage
            throw new NotImplementedException();
        }
    }
}
