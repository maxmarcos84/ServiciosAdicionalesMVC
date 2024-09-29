using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiciosAdicionales.Models;

public class Servicio
{
    public int Id { get; set; }

    [ForeignKey("PedidoDeServicio")]
    public int PedidoDeServicioId { get; set; }
    public PedidoDeServicios pedidoDeServicios { get; set; }

    [ForeignKey("TipoAdicional")]
    public int TipoAdicionalId { get; set; }
    public TipoAdicional tipoAdicional{ get; set; }
    public string Justificacion { get; set; }

    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public TimeOnly? HoraInicio {get; set;}
    public TimeOnly? HoraFin {get; set;} 

    public int? CantidadDias {get; set;}
    public int? CantidadHoras {get; set;}

    


}
