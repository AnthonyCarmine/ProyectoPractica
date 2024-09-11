using Microsoft.AspNetCore.Identity;
using ProyectoCelsiaSolucion.Interfaces;
using ProyectoCelsiaSolucion.Models;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UserManager<Administrator> _userManager;

        public LoginRepository(UserManager<Administrator> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Administrator?> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }
    }
}