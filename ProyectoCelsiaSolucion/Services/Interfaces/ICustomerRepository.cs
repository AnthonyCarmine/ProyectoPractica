using ProyectoCelsiaSolucion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task<IEnumerable<Customer>> SearchCustomers(string query);
        Task DeleteAllCustomers(); 
    }
}