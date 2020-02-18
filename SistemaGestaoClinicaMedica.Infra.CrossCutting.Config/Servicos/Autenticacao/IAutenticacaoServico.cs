using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao
{
    public interface IAutenticacaoServico
    {
        AutenticacaoResultado Autenticar(Funcionario funcionario);
    }
}