using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCelsiaSolucion.Interfaces;
using ProyectoCelsiaSolucion.Models;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Controllers
{
    [Authorize]
    public class CustomerUpdateController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUpdateController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Método para obtener los datos del cliente y mostrarlos en la vista de edición
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View("/Views/Customer/Update.cshtml", customer);
        }

        // Método para manejar la actualización del cliente
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.UpdateCustomer(customer);
                return RedirectToAction("Index", "Customer");
            }
            return View("/Views/Customer/Update.cshtml", customer);
        }
    }
}


