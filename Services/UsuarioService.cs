using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services.Interfaces;

namespace ServiciosAdicionales.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error inesperado al intentar actualizar usuario: " + ex.ToString());
            }
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error inesperado al intentar crear usuario: " + ex.ToString());
            }
        }

        public async Task<bool> EliminarUsuarioAsync(string id)
        {
            var usuarioExiste = await _context.Usuarios.FindAsync(id);
            if(usuarioExiste == null)
            {
                return false;
            }
            usuarioExiste.Activo = false;
            return await ActualizarUsuarioAsync(usuarioExiste);
        }

        public async Task<Usuario?> ObtenerUsuarioPorIdAsync(string id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios.Where(u => u.Activo == true).ToListAsync();
        }
    }
}
