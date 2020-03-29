using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.TypeConverters
{
    public abstract class UsuarioDTOParaUsuarioViewModelBase<TDTO> : ITypeConverter<TDTO, UsuarioViewModel>
        where TDTO : UsuarioDTO
    {
        public virtual UsuarioViewModel Convert(TDTO source, UsuarioViewModel destination, ResolutionContext context)
        {
            destination = new UsuarioViewModel
            {
                Id = source.Id,
                CargoId = source.Cargo.Id,
                Nome = source.Nome,
                Email = source.Email,
                Telefone = source.Telefone,
                Senha = source.Senha,
                Ativo = source.Ativo
            };

            return destination;
        }
    }
}
