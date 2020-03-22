using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Extensions
{
    public static class EnumExtension
    {
        public static IEnumerable<EStatusConsulta> StringParaStatusConsulta(this string status)
        {
            if (string.IsNullOrEmpty(status))
                yield break;

            var listaStatus = status.Split('|');
            foreach (var sts in listaStatus)
                if (Enum.TryParse(sts, out EStatusConsulta eStatusConsulta))
                    yield return eStatusConsulta;
        }
    }
}
