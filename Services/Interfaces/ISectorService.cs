using System;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Services.Interfaces;

public interface ISectorService
{
    Task<Sector> CrearSectorAsync(Sector sector);
    Task<IEnumerable<Sector>> ObtenerSectoresAsync();
    Task<Sector?> ObtenerSectorsPorIdAsync(int id);
    Task<bool> ActualizarSectorAsync(Sector sector);
    Task<bool> EliminarSectorAsync(int id);

}
