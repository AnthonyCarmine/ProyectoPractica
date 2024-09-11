using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCelsiaSolucion.Interfaces;
using ProyectoCelsiaSolucion.Models;
using ProyectoCelsiaSolucion.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProyectoCelsiaSolucion.Controllers
{
    [Authorize]
    public class ExcelController : Controller
    {
        private readonly IExcelRepository _excelRepository;

        public ExcelController(IExcelRepository excelRepository)
        {
            _excelRepository = excelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ExcelViewModel
            {
                Customers = await _excelRepository.GetAllCustomersAsync(),
                Invoices = await _excelRepository.GetAllInvoicesAsync(),
                Platforms = await _excelRepository.GetAllPlatformsAsync(),
                Transactions = await _excelRepository.GetAllTransactionsAsync()
            };

            return View(viewModel);
        }

        // Método para importar todos los datos desde un archivo Excel
        [HttpPost]
        public async Task<IActionResult> ImportarDatosExcel(IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                try
                {
                    await _excelRepository.ImportAllDataFromExcel(archivo);
                    ViewBag.Message = "Datos importados exitosamente.";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Error al importar datos: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Message = "Por favor, seleccione un archivo.";
            }

            var viewModel = new ExcelViewModel
            {
                Customers = await _excelRepository.GetAllCustomersAsync(),
                Invoices = await _excelRepository.GetAllInvoicesAsync(),
                Platforms = await _excelRepository.GetAllPlatformsAsync(),
                Transactions = await _excelRepository.GetAllTransactionsAsync()
            };

            return View("Index", viewModel);
        }


    }
}