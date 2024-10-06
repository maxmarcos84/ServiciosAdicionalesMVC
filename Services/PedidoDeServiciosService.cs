using System;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;

namespace ServiciosAdicionales.Services.Interfaces;

public class PedidoDeServiciosService : IPedidoDeServicioService
{
    private readonly AppDbContext _context;
    public PedidoDeServiciosService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ActualizarPedidoDeServicioAsync(PedidoDeServicios pedido)
    {
        try
        {
            _context.PedidosDeServicios.Update(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al actualizar Pedido de servicio: "+ex.ToString());
        }
    }

    public async Task<PedidoDeServicios> CrearPedidoDeServicio(PedidoDeServicios pedidoDeServicios)
    {
        try
        {
            _context.PedidosDeServicios.Add(pedidoDeServicios);
            await _context.SaveChangesAsync();
            return pedidoDeServicios;

        }
        catch (Exception ex)
        {
            throw new Exception("Se produjo un error al crear Pedido de servicio: "+ex.ToString());
        }
    }

    public async Task<bool> EliminarPedidoDeServicioAsync(int id)
    {
        var pedidoExiste = await _context.PedidosDeServicios.FindAsync(id);
        if(pedidoExiste == null)
        {
            return false;
        }
        try
        {
            _context.PedidosDeServicios.Remove(pedidoExiste);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            throw new Exception("Se produjo un error al eliminar Pedido de servicio: "+ex.ToString());
        }
    }

    public async Task<PedidoDeServicios?> ObtenerPedidoDeServiciosPorIdAsync(int id)
    {
        return await _context.PedidosDeServicios.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<PedidoDeServicios>> ObtenerPedidosDeServicioAsync()
    {
        return await _context.PedidosDeServicios.ToListAsync();
    }
}
