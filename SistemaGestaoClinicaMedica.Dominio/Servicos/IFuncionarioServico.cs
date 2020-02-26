using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IFuncionarioServico : IServicoBase<Guid, Funcionario>
    {
        Funcionario Autorizar(string email, string senha);
        IQueryable<Funcionario> ObterTudoAtivoOuInativo(bool ativo = true);
        void Deletar(Guid id);
        //Guid SalvarRetornaId(Funcionario funcionario);
    }
}
