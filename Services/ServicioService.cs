using System;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> EliminarServicioAsync(int id)
    {
        var servicioExiste = await _context.Servicios.FindAsync(id);
        if(servicioExiste == null)
        {
            return false;
        }
        try
        {
            _context.Servicios.Remove(servicioExiste);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            throw new Exception("Se produjo un error al eliminar el servicio: "+ex.ToString());
        }
        
    }

    public async Task<Servicio?> ObtenerServicioPorIdAsync(int id)
    {
        return await _context.Servicios.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Servicio>> ObtenerServiciosAsync()
    {
        return await _context.Servicios
            .Include(s => s.tipoAdicional)
            .ToListAsync();
    }
}
