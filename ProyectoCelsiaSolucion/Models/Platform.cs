using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoCelsiaSolucion.Models
{
    public class Platform
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo name es requerido")]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Transaction>? Transactions { get; set; }
    }
}