using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCelsiaSolucion.Interfaces;
using ProyectoCelsiaSolucion.Models;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Controllers
{
    [Authorize]
    public class CustomerCreateController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreateController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Create()
        {
            return View("/Views/Customer/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.CreateCustomer(customer);
                return RedirectToAction("Index", "Customer");
            }
            return View(customer);
        }
    }
}



