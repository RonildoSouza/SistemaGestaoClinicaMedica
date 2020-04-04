namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class TipoDeAtestado : IEntidade<ETipoDeAtestado>
    {
        public ETipoDeAtestado Id { get; set; }
        public string Nome { get; set; }
    }

    public enum ETipoDeAtestado
    {
        AtestadoPorDoenca,
        AtestadoParaRepousoGestante,
        AtestadoPorAcidenteDeTrabalho,
        AtestadoDeAptidaoFisica,
        AtestadoDeSanidadeFisicaMental,
        AtestadoParaAmamentação,
        AtestadoDeComparecimento,
    }
}