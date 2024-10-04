using System;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Services.Interfaces;

public interface ISitioService
{
    Task<Sitio> CrearSitioAsync(Sitio sitio);
    Task<IEnumerable<Sitio>> ObtenerSitiosAsync();
    Task<Sitio?> ObtenerSitioPorIdAsync(int id);
    Task<bool> ActualizarSitioAsync(Sitio sitio);
    Task<bool> EliminarSitioAsync(int id);

}
