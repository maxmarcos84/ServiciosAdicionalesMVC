using System;
using System.ComponentModel.DataAnnotations.Schema;
using ServiciosAdicionales.Data.Enum;


namespace ServiciosAdicionales.Models;

public class PedidoDeServicios
{
    public int Id { get; set; }

    [ForeignKey("Solicitante")]
    public int SolicitanteId { get; set; }
    public Usuario Solicitante { get; set; }

    [ForeignKey("Empleado")]
    public int EmpleadoId { get; set; }
    public Usuario Empleado { get; set; }

    [ForeignKey("Sitio")]
    public int SitioId { get; set; }

    public TipoPedido tipoPedido{ get; set; }
    public EstadoPedido estadoPedido{ get; set; }

    public ICollection<Servicio>? Servicios { get; set; }


}
