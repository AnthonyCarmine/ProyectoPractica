using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoCelsiaSolucion.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo number es requerido")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo de fecha es requerido")]
        public DateOnly Date { get; set; }

        [Required(ErrorMessage = "El campo de cantidad de la factura es requerido")]
        public int AmountInvoice { get; set; }

        [Required(ErrorMessage = "El campo de cantidad pagada es requerido")]
        public int AmountPaid { get; set; }
        
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        [JsonIgnore]
        public List<Transaction>? Transactions { get; set; }

    }
}

