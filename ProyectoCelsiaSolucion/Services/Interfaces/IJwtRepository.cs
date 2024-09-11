using ProyectoCelsiaSolucion.Models;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Interfaces
{
public interface IJwtRepository
{
    string GenerateToken(string userId);
}
}