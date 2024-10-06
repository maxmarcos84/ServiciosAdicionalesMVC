using System;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Services.Interfaces;

public interface IPedidoDeServicioService
{
    Task<PedidoDeServicios> CrearPedidoDeServicio(PedidoDeServicios pedidoDeServicios);
    Task<IEnumerable<PedidoDeServicios>> ObtenerPedidosDeServicioAsync();
    Task<PedidoDeServicios?> ObtenerPedidoDeServiciosPorIdAsync(int id);
    Task<bool> ActualizarPedidoDeServicioAsync(PedidoDeServicios pedido);
    Task<bool> EliminarPedidoDeServicioAsync(int id);

}
