using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Converte string com id de status de consulta separados por pipe |, para valores do enum <see cref="EStatusConsulta"/>
        /// </summary>
        public static IEnumerable<EStatusConsulta> StringParaListaDeStatusConsulta(this string status)
        {
            if (string.IsNullOrEmpty(status))
                yield break;

            var listaStatus = status.Split('|');
            foreach (var sts in listaStatus)
                yield return sts.StringParaStatusConsulta();
        }

        /// <summary>
        /// Converte string com id de status de consulta separados por pipe |, para valores do enum <see cref="EStatusExame"/>
        /// </summary>
        public static IEnumerable<EStatusExame> StringParaListaDeStatusExame(this string status)
        {
            if (string.IsNullOrEmpty(status))
                yield break;

            var listaStatus = status.Split('|');
            foreach (var sts in listaStatus)
                yield return sts.StringParaStatusExame();
        }

        public static EStatusConsulta StringParaStatusConsulta(this string status)
        {
            return status.StringParaEnum<EStatusConsulta>();
        }

        public static EStatusExame StringParaStatusExame(this string status)
        {
            return status.StringParaEnum<EStatusExame>();
        }

        public static ETipoDeAtestado StringParaTipoDeAtestado(this string status)
        {
            return status.StringParaEnum<ETipoDeAtestado>();
        }

        private static T StringParaEnum<T>(this string str) where T : struct, Enum
        {
            if (!Enum.TryParse(str, out T e))
                throw new Exception($"Não foi possível converter a string {str}, para um valor do enum {nameof(T)}!");

            return e;
        }
    }
}
