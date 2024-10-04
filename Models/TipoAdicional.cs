namespace ServiciosAdicionales.Models
{
    public class TipoAdicional
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
