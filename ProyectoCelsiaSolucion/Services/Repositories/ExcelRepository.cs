using ProyectoCelsiaSolucion.Data;
using ProyectoCelsiaSolucion.Models;
using ProyectoCelsiaSolucion.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ProyectoCelsiaSolucion.Repositories
{
    public class ExcelRepository : IExcelRepository
    {
        private readonly BaseContext _context;

        public ExcelRepository(BaseContext context)
        {
            _context = context;
        }

             public async Task ImportAllDataFromExcel(IFormFile file)
        {
            using (var workbook = new XLWorkbook(file.OpenReadStream()))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RowsUsed().Skip(1);

                var customers = new List<Customer>();

                foreach (var row in rows)
                {
                    // Procesar datos del cliente
                    var customer = new Customer
                    {
                        Names = row.Cell(6).GetValue<string>(),
                        Document = row.Cell(7).GetValue<int>(),
                        Address = row.Cell(8).GetValue<string>(),
                        Phone = row.Cell(9).GetValue<string>(),
                        Email = row.Cell(10).GetValue<string>()
                    };
                    customers.Add(customer);
                }

                // Insertar datos en la base de datos
                _context.Customers.AddRange(customers);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<FileResult> ExportCustomersToExcel(string fileName, IEnumerable<Customer> customers)
        {
            DataTable dataTable = new DataTable("Customers");
            dataTable.Columns.AddRange(new DataColumn[5]
            {
                new DataColumn("Names", typeof(string)),
                new DataColumn("Document", typeof(int)),
                new DataColumn("Address", typeof(string)),
                new DataColumn("Phone", typeof(string)),
                new DataColumn("Email", typeof(string))
            });

            foreach (Customer customer in customers)
            {
                dataTable.Rows.Add(customer.Names, customer.Document, customer.Address, customer.Phone, customer.Email);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dataTable);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return new FileContentResult(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = fileName
                    };
                }
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddCustomersAsync(IEnumerable<Customer> customers)
        {
            _context.AddRange(customers);
            await _context.SaveChangesAsync();
        }

        public async Task<FileResult> ExportInvoicesToExcel(string fileName, IEnumerable<Invoice> invoices)
        {
            DataTable dataTable = new DataTable("Invoices");
            dataTable.Columns.AddRange(new DataColumn[5]
            {
                new DataColumn("Number", typeof(string)),
                new DataColumn("Date", typeof(string)),
                new DataColumn("AmountInvoice", typeof(int)),
                new DataColumn("AmountPaid", typeof(int)),
                new DataColumn("CustomerId", typeof(int))
            });

            foreach (Invoice invoice in invoices)
            {
                dataTable.Rows.Add(invoice.Number, invoice.Date, invoice.AmountInvoice, invoice.AmountPaid, invoice.CustomerId);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dataTable);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return new FileContentResult(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = fileName
                    };
                }
            }
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task AddInvoicesAsync(IEnumerable<Invoice> invoices)
        {
            _context.AddRange(invoices);
            await _context.SaveChangesAsync();
        }

        public async Task<FileResult> ExportPlatformsToExcel(string fileName, IEnumerable<Platform> platforms)
        {
            DataTable dataTable = new DataTable("Platforms");
            dataTable.Columns.AddRange(new DataColumn[1]
            {
                new DataColumn("Name", typeof(string))
            });

            foreach (Platform platform in platforms)
            {
                dataTable.Rows.Add(platform.Name);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dataTable);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return new FileContentResult(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = fileName
                    };
                }
            }
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task AddPlatformsAsync(IEnumerable<Platform> platforms)
        {
            _context.AddRange(platforms);
            await _context.SaveChangesAsync();
        }

        public async Task<FileResult> ExportTransactionsToExcel(string fileName, IEnumerable<Transaction> transactions)
        {
            DataTable dataTable = new DataTable("Transactions");
            dataTable.Columns.AddRange(new DataColumn[7]
            {
                new DataColumn("Id", typeof(string)),
                new DataColumn("DateHour", typeof(DateTime)),
                new DataColumn("Amount", typeof(decimal)),
                new DataColumn("Status", typeof(string)),
                new DataColumn("Type", typeof(string)),
                new DataColumn("PlatformId", typeof(int)),
                new DataColumn("InvoiceId", typeof(int))
            });

            foreach (var transaction in transactions)
            {
                dataTable.Rows.Add(
                    transaction.Id,
                    transaction.DateHour,
                    transaction.Amount,
                    transaction.Status,
                    transaction.Type,
                    transaction.PlatformId,
                    transaction.InvoiceId
                );
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(dataTable);
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return new FileContentResult(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = fileName
                    };
                }
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task AddTransactionsAsync(IEnumerable<Transaction> transactions)
        {
            _context.AddRange(transactions);
            await _context.SaveChangesAsync();
        }
    }
}

