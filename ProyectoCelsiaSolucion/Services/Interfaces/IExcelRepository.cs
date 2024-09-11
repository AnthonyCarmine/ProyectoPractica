using ProyectoCelsiaSolucion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Interfaces
{
    public interface IExcelRepository
    {
        // Import all data from a single Excel file
        Task ImportAllDataFromExcel(IFormFile file);

        // Customer
        Task<FileResult> ExportCustomersToExcel(string fileName, IEnumerable<Customer> customers);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task AddCustomersAsync(IEnumerable<Customer> customers);

        // Transaction
        Task<FileResult> ExportTransactionsToExcel(string fileName, IEnumerable<Transaction> transactions);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task AddTransactionsAsync(IEnumerable<Transaction> transactions);

        // Platforms
        Task<FileResult> ExportPlatformsToExcel(string fileName, IEnumerable<Platform> platforms);
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task AddPlatformsAsync(IEnumerable<Platform> platforms);

        // Invoices
        Task<FileResult> ExportInvoicesToExcel(string fileName, IEnumerable<Invoice> invoices);
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task AddInvoicesAsync(IEnumerable<Invoice> invoices);
    }
}