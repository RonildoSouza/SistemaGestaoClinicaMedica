using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ExameServicoAplicacao : ServicoAplicacaoBase<Exame, ExameSaidaDTO, ExameEntradaDTO, Guid>, IExameServicoAplicacao
    {
        private readonly IExameServico _exameServico;

        public ExameServicoAplicacao(IMapper mapper, IExameServico exameServico) : base(mapper, exameServico)
        {
            _exameServico = exameServico;
        }

        public ExameSaidaDTO Obter(string codigo)
        {
            var entidade = _exameServico.Obter(codigo);
            return _mapper.Map<ExameSaidaDTO>(entidade);
        }

        public void UploadResultado(Guid id, ArquivoResultadoExameEntradaDTO arquivoDTO)
        {
            //TODO: Adicionar package para armazenar os arquivos no Azure Storage
            throw new NotImplementedException();
        }
    }
}
