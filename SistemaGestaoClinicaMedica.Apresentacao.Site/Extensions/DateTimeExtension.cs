using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToDateAndTime(this DateTime dateTime)
        {
            return dateTime.ToString("dddd, dd \\de MMMM, yyyy á\\s HH:mm");
        }
    }
}
