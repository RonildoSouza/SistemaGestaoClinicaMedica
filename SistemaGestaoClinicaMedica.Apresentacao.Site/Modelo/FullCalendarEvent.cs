using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo
{
    public sealed class FullCalendarEvent
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public string Description { get; set; }
        public dynamic ExtendedProps { get; set; }
        public string BackgroundColor => "green";
        public string TextColor => "white";
    }
}
