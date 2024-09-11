using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCelsiaSolucion.Interfaces;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Controllers
{
    [Authorize]
    public class CustomerDeleteController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDeleteController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerRepository.DeleteCustomer(customer);
            return RedirectToAction("Index", "Customer");
        }

        // Método para mostrar la vista de confirmación para eliminar todos los clientes
        public IActionResult DeleteAll()
        {
            return View();
        }

        // Método para confirmar la eliminación de todos los clientes
        [HttpPost, ActionName("DeleteAll")]
        public async Task<IActionResult> DeleteAllConfirmed()
        {
            await _customerRepository.DeleteAllCustomers();
            return RedirectToAction("Index", "Customer");
        }
    }
}

