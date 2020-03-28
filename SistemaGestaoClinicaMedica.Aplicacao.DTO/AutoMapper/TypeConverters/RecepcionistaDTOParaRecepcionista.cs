using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class RecepcionistaDTOParaRecepcionista : ITypeConverter<RecepcionistaDTO, Recepcionista>
    {
        private readonly IRecepcionistaServico _recepcionistaServico;

        public RecepcionistaDTOParaRecepcionista(IRecepcionistaServico recepcionistaServico)
        {
            _recepcionistaServico = recepcionistaServico;
        }

        public Recepcionista Convert(RecepcionistaDTO source, Recepcionista destination, ResolutionContext context)
        {
            source.Cargo.Id = "Recepcionista";

            var usuario = context.Mapper.Map<Usuario>(source);
            var recepcionista = new Recepcionista(usuario)
            {
                // Recupera id da tabela de relacionamento
                Id = _recepcionistaServico.Obter(usuario.Id, true)?.Id ?? Guid.Empty
            };

            return recepcionista;
        }
    }
}
