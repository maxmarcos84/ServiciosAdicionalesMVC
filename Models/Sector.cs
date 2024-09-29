namespace ServiciosAdicionales.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }

    }
}
