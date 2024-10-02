using System;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Services.Interfaces;

public interface IServicioService
{
    Task<Servicio> CrearServicioAsync(Servicio servicio);
    Task<IEnumerable<Servicio>> ObtenerServiciosAsync();
    Task<Servicio?> ObtenerServicioPorIdAsync(int id);
    Task<bool> ActualizarServicioAsync(Servicio servicio);
    Task<bool> EliminarServicioAsync(int id);


}
