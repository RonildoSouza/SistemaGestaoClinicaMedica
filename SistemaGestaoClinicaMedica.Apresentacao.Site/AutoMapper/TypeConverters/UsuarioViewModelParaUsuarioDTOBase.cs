using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters
{
    public abstract class UsuarioViewModelParaUsuarioDTOBase<TDTO> : ITypeConverter<UsuarioViewModel, TDTO>
        where TDTO : UsuarioDTO
    {
        public virtual TDTO Convert(UsuarioViewModel source, TDTO destination, ResolutionContext context)
        {
            destination = Activator.CreateInstance(typeof(TDTO)) as TDTO;

            destination.Id = source.Id;
            destination.Nome = source.Nome;
            destination.Email = source.Email;
            destination.Telefone = source.Telefone;
            destination.Senha = source.Senha;
            destination.Ativo = source.Ativo;

            return destination;
        }
    }
}
