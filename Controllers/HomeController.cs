using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services;
using ServiciosAdicionales.Services.Interfaces;
using ServiciosAdicionales.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace ServiciosAdicionales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioService _usuarioService;
        private readonly IPedidoDeServicioService _pedidoDeServicioService;

        public HomeController(ILogger<HomeController> logger, UserManager<Usuario> userManager, IUsuarioService usuarioService, IPedidoDeServicioService pedidosService)
        {
            _logger = logger;
            _userManager = userManager;
            _usuarioService = usuarioService;
            _pedidoDeServicioService = pedidosService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(userId);
                if(usuario != null)
                {
                    var pedidos = await _pedidoDeServicioService.ObtenerPedidosDeSerivicioPorEmpleado(usuario);
                    var lista = pedidos.Select(p => new PedidoDeServicioViewModel
                    {
                        Id = p.Id.ToString(),
                        FechaSolicitado = p.FechaSolicitado,
                        FechaFinalizado = p.FechaFinalizado,
                        Estado = p.estadoPedido.ToString()
                    }).ToList();
                    return View(lista);
                }                
            }
            
            return View(new List<PedidoDeServicioViewModel>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
