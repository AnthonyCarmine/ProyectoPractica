using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoCelsiaSolucion.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo name es requerido")]
        public string? Names { get; set; }

        [Required(ErrorMessage = "El campo del documento es requerido")]
        public int Document { get; set; }

        [Required(ErrorMessage = "El campo address es requerido")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "El campo phone es requerido")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "El campo email es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Invoice>? Invoices { get; set; } 
    }
}

