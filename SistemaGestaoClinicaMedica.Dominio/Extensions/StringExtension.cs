namespace SistemaGestaoClinicaMedica.Dominio.Extensions
{
    public static class StringExtension
    {
        public static bool ToLowerContains(this string str, string busca) => str.ToLower().Contains(busca.ToLower());

        public static bool ToLowerStartsWith(this string str, string busca) => str.ToLower().StartsWith(busca.ToLower());
    }
}
