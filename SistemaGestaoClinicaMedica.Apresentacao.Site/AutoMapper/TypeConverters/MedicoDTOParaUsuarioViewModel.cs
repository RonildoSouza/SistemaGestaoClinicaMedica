using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters
{
    public class MedicoDTOParaUsuarioViewModel : UsuarioDTOParaUsuarioViewModelBase<MedicoDTO>
    {
        public override UsuarioViewModel Convert(MedicoDTO source, UsuarioViewModel destination, ResolutionContext context)
        {
            destination = base.Convert(source, destination, context);

            destination.CRM = source.CRM;

            destination.Especialidades = source.Especialidades
                        .Select(_ => UsuarioViewModel.ControiMedicoEspecialidade(_.Id, _.EspecialidadeId, _.Ativo))
                        .ToList();

            for (int i = 0; i < source.HorariosDeTrabalho.Count; i++)
            {
                var horarioDeTrabalho = source.HorariosDeTrabalho[i];
                var indiceDoDiaDaSemana = destination.HorariosDeTrabalho.FindIndex(_ => _.DiaDaSemana.Item1 == horarioDeTrabalho.DiaDaSemana);

                if (indiceDoDiaDaSemana < 0)
                    continue;

                DateTime.TryParse(horarioDeTrabalho.Inicio, out DateTime inicio);
                DateTime.TryParse(horarioDeTrabalho.InicioIntervalo, out DateTime inicioIntervalo);
                DateTime.TryParse(horarioDeTrabalho.FimIntervalo, out DateTime fimIntervalo);
                DateTime.TryParse(horarioDeTrabalho.Fim, out DateTime fim);

                destination.HorariosDeTrabalho[indiceDoDiaDaSemana].Id = horarioDeTrabalho.Id;
                destination.HorariosDeTrabalho[indiceDoDiaDaSemana].Inicio = inicio;
                destination.HorariosDeTrabalho[indiceDoDiaDaSemana].InicioIntervalo = inicioIntervalo;
                destination.HorariosDeTrabalho[indiceDoDiaDaSemana].FimIntervalo = fimIntervalo;
                destination.HorariosDeTrabalho[indiceDoDiaDaSemana].Fim = fim;
                destination.HorariosDeTrabalho[indiceDoDiaDaSemana].Selecionado = horarioDeTrabalho.Ativo;
            }

            return destination;
        }
    }
}
