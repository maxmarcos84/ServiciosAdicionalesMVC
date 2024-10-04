using System;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Services.Interfaces;

public interface ITipoAdicionalService
{
    Task<TipoAdicional> CrearTipoAdicionalAsync(TipoAdicional tipoAdicional);
    Task<IEnumerable<TipoAdicional>> ObtenerTipoAdicionalesAsync();
    Task<TipoAdicional?> ObtenerTipoAdicionalPorIdAsync(int id);
    Task<bool> ActualizarTipoAdicionalAsync(TipoAdicional tipoAdicional);
    Task<bool> EliminarTipoAdicionalAsync(int id); 
}
