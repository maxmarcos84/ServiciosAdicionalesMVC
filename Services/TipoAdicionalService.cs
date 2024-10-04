using System;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services.Interfaces;

namespace ServiciosAdicionales.Services;

public class TipoAdicionalService : ITipoAdicionalService
{
    private readonly AppDbContext _context;
    public TipoAdicionalService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ActualizarTipoAdicionalAsync(TipoAdicional tipoAdicional)
    {
        try
        {
            _context.TiposAdicional.Update(tipoAdicional);
            await _context.SaveChangesAsync();
            return true;

        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al actualizar Tipo de servicio: "+ex.ToString());
        }
    }

    public async Task<TipoAdicional> CrearTipoAdicionalAsync(TipoAdicional tipoAdicional)
    {
        try
        {
            _context.TiposAdicional.Add(tipoAdicional);
            await _context.SaveChangesAsync();
            return tipoAdicional;
        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al crear TipoAdicional: "+ex.ToString());
        }
    }

    public async Task<bool> EliminarTipoAdicionalAsync(int id)
    {
        var tipoAdicionalExists = await _context.TiposAdicional.FindAsync(id);
        if (tipoAdicionalExists == null)
        {
            return false;
        }
        tipoAdicionalExists.Activo = false;
        return await ActualizarTipoAdicionalAsync(tipoAdicionalExists);
    }

    public async Task<IEnumerable<TipoAdicional>> ObtenerTipoAdicionalesAsync()
    {
        return await _context.TiposAdicional.Where(t => t.Activo == true).ToListAsync();
    }

    public async Task<TipoAdicional?> ObtenerTipoAdicionalPorIdAsync(int id)
    {
        return await _context.TiposAdicional.FirstOrDefaultAsync(t => t.Id == id);
    }
}
