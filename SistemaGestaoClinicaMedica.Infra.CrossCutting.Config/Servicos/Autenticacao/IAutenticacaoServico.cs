using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao
{
    public interface IAutenticacaoServico
    {
        AutenticacaoSaida Autenticar(AutenticacaoEntrada entrada);
    }
}