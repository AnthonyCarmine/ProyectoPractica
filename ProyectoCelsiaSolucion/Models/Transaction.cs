using System.ComponentModel.DataAnnotations;

namespace ProyectoCelsiaSolucion.Models
{
    public class Transaction
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "El campo de fecha y hora es requerido")]
        public DateTime DateHour { get; set; }

        [Required(ErrorMessage = "El campo de cantidad es requerido")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "El campo de estado es requerido")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "El campo de tipo es requerido")]
        public string? Type { get; set; }
        
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }


    }
}