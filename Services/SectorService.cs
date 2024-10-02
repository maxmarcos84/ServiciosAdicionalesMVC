using System;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services.Interfaces;

namespace ServiciosAdicionales.Services;

public class SectorService : ISectorService
{
    private readonly AppDbContext _context;
    public SectorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ActualizarSectorAsync(Sector sector)
    {
        try
        {
            _context.Sector.Update(sector);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al actualizar Sector: "+ex.ToString());
        }
    }

    public async Task<Sector> CrearSectorAsync(Sector sector)
    {
        _context.Sector.Add(sector);
        await _context.SaveChangesAsync();
        return sector;
    }

    public async Task<bool> EliminarSectorAsync(int id)
    {
        var sectorExiste = await _context.Sector.FindAsync(id);
        if(sectorExiste == null)
        {
            return false;
        }
        sectorExiste.Activo = false;
        return await ActualizarSectorAsync(sectorExiste);
    }

    public async Task<IEnumerable<Sector>> ObtenerSectoresAsync()
    {
        return await _context.Sector.Where(s => s.Activo).ToListAsync();
    }

    public async Task<Sector?> ObtenerSectorsPorIdAsync(int id)
    {
        return await _context.Sector.FirstOrDefaultAsync(s => s.Id == id);
    }
}
