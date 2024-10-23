using Microsoft.AspNetCore.Mvc;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Services.Interfaces;
using ServiciosAdicionales.ViewModels;

namespace ServiciosAdicionales.Controllers
{
    public class PedidosDeServiciosController : Controller
    {
        private IPedidoDeServicioService _pedidosContext;
        public PedidosDeServiciosController(IPedidoDeServicioService pedidosContext)
        {
            _pedidosContext = pedidosContext;
        }

        [HttpGet]
        public IActionResult CrearPedidoServicio() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPedidoServicio(PedidoDeServicioViewModel model)
        {
            if(ModelState.IsValid)
            {
                var pedido = new PedidoDeServicios
                {
                    SolicitanteId = model.IdSolicitante,
                    EmpleadoId = model.IdEmpleado,
                    FechaSolicitado = model.FechaSolicitado,
                    tipoPedido = model.TipoDePedido
                };
                return View(_pedidosContext.CrearPedidoDeServicio(pedido));
            }

            return View(model);
        }
      
    }
}
