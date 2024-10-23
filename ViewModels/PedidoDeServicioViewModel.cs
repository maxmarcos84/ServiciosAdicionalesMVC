using ServiciosAdicionales.Data.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiciosAdicionales.ViewModels
{
    public class PedidoDeServicioViewModel
    {
        public string Id { get; set; }

        public string IdSolicitante { get; set; }
        public string IdEmpleado { get; set; }
        public DateOnly FechaSolicitado { get; set; }

        public DateOnly? FechaFinalizado { get; set; }

        public TipoPedido TipoDePedido { get; set; }
        public string Estado {  get; set; }
    }
}
