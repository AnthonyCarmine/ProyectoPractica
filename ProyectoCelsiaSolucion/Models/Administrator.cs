using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Asegúrate de tener esta línea

namespace ProyectoCelsiaSolucion.Models
{
    public class Administrator : IdentityUser
    {
        [Required(ErrorMessage = "El campo email es requerido")]
        public override string Email { get; set; }

        [Required(ErrorMessage = "El campo password es requerido")]
        [JsonIgnore] // Para evitar que la contraseña se serialice
        public string Password { get; set; }
    }
}