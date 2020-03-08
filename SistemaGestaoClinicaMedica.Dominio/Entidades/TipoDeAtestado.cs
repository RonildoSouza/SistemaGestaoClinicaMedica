namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class TipoDeAtestado : IEntidade<ETipoDeAtestado>
    {
        public ETipoDeAtestado Id { get; set; }
        public string Nome { get; set; }
    }

    public enum ETipoDeAtestado
    {
        AtestadoDeObito,
        AtestadoPorDoenca,
        AtestadoParaRepousoGestante,
        AtestadoPorAcidenteDeTrabalho,
        AtestadoParaFinsDeInterdicao,
        AtestadoDeAptidaoFisica,
        AtestadoDeSanidadeFisicaMental,
        AtestadoParaAmamentação,
        AtestadoDeComparecimento,
        AtestadoParaInternacoes,
    }
}