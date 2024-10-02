using System;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services.Interfaces;

namespace ServiciosAdicionales.Services;

public class ServicioService : IServicioService
{
    private readonly AppDbContext _context;

    public ServicioService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ActualizarServicioAsync(Servicio servicio)
    {
        try
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al actualizar Servicio: "+ex.ToString());
        }
    }

    public async Task<Servicio> CrearServicioAsync(Servicio servicio)
    {
        try
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }
        catch(Exception ex)
        {
            throw new Exception("Se produjo un error al intentar salvar el Servicio: "+ ex.ToString());
        }
    }

    public Task<bool> EliminarServicioAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Servicio?> ObtenerServicioPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Servicio>> ObtenerServiciosAsync()
    {
        throw new NotImplementedException();
    }
}
