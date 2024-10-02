using System;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Services;

public interface IEmpresaService
{
    Task<Empresa> CrearEmpresaAsync(Empresa empresa);
    Task<IEnumerable<Empresa>> ObtenerEmpresasAsync();
    Task<Empresa?> ObtenerEmpresaPorIdAsync(int id);
    Task<bool> ActualizarEmpresaAsync(Empresa empresa);
    Task<bool> EliminarEmpresaAsync(int id);

}
