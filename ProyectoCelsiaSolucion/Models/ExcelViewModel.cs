using ProyectoCelsiaSolucion.Models;

namespace ProyectoCelsiaSolucion.ViewModels
{
    public class ExcelViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}


