using Microsoft.EntityFrameworkCore;
using ProyectoCelsiaSolucion.Interfaces;
using ProyectoCelsiaSolucion.Models;
using ProyectoCelsiaSolucion.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoCelsiaSolucion.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaseContext _context;

        public CustomerRepository(BaseContext context)
        {
            _context = context;
        }

        // Método para obtener todos los clientes
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // Método para obtener un cliente por ID
        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        // Método para eliminar un cliente
        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        // Método para crear un nuevo cliente
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        // Método para actualizar un cliente existente
        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

         public async Task<IEnumerable<Customer>> SearchCustomers(string query)
        {
            return await _context.Customers.Where(c => c.Names != null && c.Names.Contains(query) || c.Document.ToString().Contains(query) || c.Email != null && c.Email.Contains(query)).ToListAsync();
        }

           public async Task DeleteAllCustomers()
        {
            var allCustomers = await _context.Customers.ToListAsync();
            _context.Customers.RemoveRange(allCustomers);
            await _context.SaveChangesAsync();
        }
    }
}

