using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters
{
    public class UsuarioViewModelParaMedicoDTO : UsuarioViewModelParaUsuarioDTOBase<MedicoDTO>
    {
        public override MedicoDTO Convert(UsuarioViewModel source, MedicoDTO destination, ResolutionContext context)
        {
            destination = base.Convert(source, destination, context);

            destination.CRM = source.CRM;

            destination.Especialidades = source.Especialidades
                            .Select(_ => new MedicoEspecialidadeDTO
                            {
                                Id = _.Id,
                                EspecialidadeId = _.EspecialidadeId,
                                Ativo = _.Ativo
                            }).ToList();

            destination.HorariosDeTrabalho = source.HorariosDeTrabalho
                            .Select(_ => new HorarioDeTrabalhoDTO
                            {
                                Id = _.Id,
                                DiaDaSemana = _.DiaDaSemana.Item1,
                                Inicio = _.Inicio.TimeOfDay.ToString(),
                                InicioIntervalo = _.InicioIntervalo.TimeOfDay.ToString(),
                                FimIntervalo = _.FimIntervalo.TimeOfDay.ToString(),
                                Fim = _.Fim.TimeOfDay.ToString(),
                                Ativo = _.Selecionado
                            }).ToList();

            return destination;
        }
    }
}
