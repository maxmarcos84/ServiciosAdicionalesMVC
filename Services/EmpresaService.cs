using System;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;

namespace ServiciosAdicionales.Services;

public class EmpresaService : IEmpresaService
{
    private readonly AppDbContext _context;
    public EmpresaService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ActualizarEmpresaAsync(Empresa empresa)
    {
        
        try
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error inesperado al intentar actualizar la empresa: "+ex.ToString());
        }
    }

    public async Task<Empresa> CrearEmpresaAsync(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        return empresa;
    }

    public async Task<bool> EliminarEmpresaAsync(int id)
    {
        var empresaExiste = await _context.Empresas.FindAsync(id);
        if (empresaExiste == null)
        {
            return false;
        }
        empresaExiste.Activa = false;
        return await ActualizarEmpresaAsync(empresaExiste);
    }

    public async Task<Empresa?> ObtenerEmpresaPorIdAsync(int id)
    {
        return await _context.Empresas.FirstOrDefaultAsync(emp => emp.Id == id);
    }

    public async Task<IEnumerable<Empresa>> ObtenerEmpresasAsync()
    {
        return await _context.Empresas.Where(emp => emp.Activa== true).ToListAsync();
    }
}
