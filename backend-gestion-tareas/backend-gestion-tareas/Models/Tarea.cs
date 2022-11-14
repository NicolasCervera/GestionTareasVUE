using System.ComponentModel.DataAnnotations;

namespace back_gestion_tareas.Models
{
    public class Tarea
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
