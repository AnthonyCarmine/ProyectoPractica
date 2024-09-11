using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCelsiaSolucion.Interfaces;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Json(customer);
        }

        public async Task<IActionResult> Search(string query)
        {
            var customers = await _customerRepository.SearchCustomers(query);
            return View("Index", customers);
        }
    }
}