using System.Threading.Tasks;
using ProyectoCelsiaSolucion.Models;

namespace ProyectoCelsiaSolucion.Interfaces
{
    public interface ILoginRepository
    {
        Task<Administrator?> Login(string email, string password);
    }
}