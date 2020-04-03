using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Storage;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class ExameServicoAplicacao : ServicoAplicacaoBase<ExameDTO, Guid, Exame>, IExameServicoAplicacao
    {
        private readonly IExameServico _exameServico;
        private readonly IAzureStorage _azureStorage;

        public ExameServicoAplicacao(IMapper mapper, IExameServico exameServico, IAzureStorage azureStorage) : base(mapper, exameServico)
        {
            _exameServico = exameServico;
            _azureStorage = azureStorage;
        }

        public void AlterarStatus(Guid id, StatusExameDTO statusExame)
        {
            var eStatusExame = statusExame.Id.StringParaStatusExame();
            _exameServico.AlterarStatus(id, eStatusExame);
        }

        public ExameDTO Obter(string codigo)
        {
            var entidade = _exameServico.ObterPorCodigo(codigo);
            return _mapper.Map<ExameDTO>(entidade);
        }

        public IList<ExameDTO> ObterTudoComFiltro(string busca)
        {
            var entidades = _exameServico.ObterTudoComFiltro(busca);
            return _mapper.Map<List<ExameDTO>>(entidades);
        }

        public IList<ExameDTO> ObterTudoPorConsultaId(Guid consultaId)
        {
            var entidades = _exameServico.ObterTudoPorConsultaId(consultaId);
            return _mapper.Map<List<ExameDTO>>(entidades);
        }

        public Uri UploadResultado(Guid id, ArquivoResultadoExameDTO arquivoDTO)
        {
            var uri = _azureStorage.UploadDeArquivo(arquivoDTO.StreamArquivo, $"resultado-exames/{id}_{arquivoDTO.NomeArquivo}");

            if (uri != null)
            {
                var exame = _exameServico.Obter(id);
                exame.LinkResultadoExame = uri.AbsoluteUri;
                _exameServico.Salvar(exame);
            }

            return uri;
        }
    }
}
