using System.ComponentModel.DataAnnotations.Schema;

namespace ServiciosAdicionales.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string IGG { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }

        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public bool Solicitante { get; set; }
        public bool Activo {  get; set; }

    }
}
