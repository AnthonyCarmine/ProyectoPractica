using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoCelsiaSolucion.Interfaces;
using ProyectoCelsiaSolucion.Models;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Administrator> _userManager;
        private readonly SignInManager<Administrator> _signInManager;
        private readonly IJwtRepository _jwtRepository;

        public LoginController(UserManager<Administrator> userManager, SignInManager<Administrator> signInManager, IJwtRepository jwtRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtRepository = jwtRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Administrator();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Administrator model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = _jwtRepository.GenerateToken(user.Id);

                    Response.Cookies.Append("jwt", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTimeOffset.UtcNow.AddHours(1)
                    });

                    return RedirectToAction("Index", "Excel");
                }

                ModelState.AddModelError(string.Empty, "Invalid credentials");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Index", "Login");
        }
    }
}