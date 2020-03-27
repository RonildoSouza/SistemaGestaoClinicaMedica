using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Servico.Api.Models
{
    public class ResponseList<T>
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public IList<T> Data { get; set; }
    }
}
