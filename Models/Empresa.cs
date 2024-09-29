namespace ServiciosAdicionales.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set;}
        public bool Activa {  get; set;}

        public ICollection<Usuario>? Usuarios { get; set; }


    }
}
