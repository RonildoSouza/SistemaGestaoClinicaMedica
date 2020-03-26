using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class ExameServicoAplicacao : ServicoAplicacaoBase<ExameDTO, Guid, Exame>, IExameServicoAplicacao
    {
        private readonly IExameServico _exameServico;

        public ExameServicoAplicacao(IMapper mapper, IExameServico exameServico) : base(mapper, exameServico)
        {
            _exameServico = exameServico;
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

        public IList<ExameDTO> ObterTudoPorConsultaId(Guid consultaId)
        {
            var entidades = _exameServico.ObterTudoPorConsultaId(consultaId);
            return _mapper.Map<List<ExameDTO>>(entidades);
        }

        public Uri UploadResultado(Guid id, ArquivoResultadoExameDTO arquivoDTO)
        {
            //TODO: Adicionar package para armazenar os arquivos no Azure Storage
            var uri = new Uri("https://lokeshdhakar.com/projects/lightbox2/images/image-3.jpg");

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
