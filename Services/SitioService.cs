using System;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services.Interfaces;

namespace ServiciosAdicionales.Services;

public class SitioService : ISitioService
{
    private readonly AppDbContext _context;
    public SitioService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ActualizarSitioAsync(Sitio sitio)
    {
        try
        {
            _context.Sitios.Update(sitio);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al actualizar el sitio: "+ex.ToString());
        }
    }

    public async Task<Sitio> CrearSitioAsync(Sitio sitio)
    {
        try
        {
            _context.Sitios.Add(sitio);
            await _context.SaveChangesAsync();
            return sitio;
        }
        catch(Exception ex)
        {
            throw new Exception("Se produjo un error al crear el Sitio: "+ex.ToString() );
        }
    }

    public async Task<bool> EliminarSitioAsync(int id)
    {
        var sitioExiste = await _context.Sitios.FindAsync(id);
        if (sitioExiste == null)
        {
            return false;
        }
        sitioExiste.Activo = false;
        return await ActualizarSitioAsync(sitioExiste);

    }

    public async Task<Sitio?> ObtenerSitioPorIdAsync(int id)
    {
        return await _context.Sitios.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Sitio>> ObtenerSitiosAsync()
    {
        return await _context.Sitios.Where(s => s.Activo == true).ToListAsync();
    }
}
