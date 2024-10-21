using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace ServiciosAdicionales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Usuario> _userManager;
        private readonly UsuarioService _usuarioService;

        public HomeController(ILogger<HomeController> logger, UserManager<Usuario> userManager, UsuarioService usuarioService)
        {
            _logger = logger;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            //Terminar esto URGENTE tiene que devolver una lista de pedidosdeservicio pero hay que hacer el viewmodel
            //de los mismos
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(userId);


                return View(new List<PedidoDeServicios>());
            }
            
            return View(new List<PedidoDeServicios>());
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
