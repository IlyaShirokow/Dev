using Kours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{
    public class InvoicesDAL
    {
        private readonly MVCProductDbContext _db;

        public InvoicesDAL(DbContextOptions<MVCProductDbContext> db)
        {
            _db = new MVCProductDbContext(db);
        }

        public async Task<List<Invoices>> GetAll()
        {
            return await _db.Invoices.ToListAsync();

        }

        public async Task<Invoices> Add(Invoices newInvoices)
        {
            var dbInvoices = new Invoices()
            {
                Id = newInvoices.Id,
                InvoiceType = newInvoices.InvoiceType,
                Descrption = newInvoices.Descrption
            };

            await _db.Invoices.AddAsync(dbInvoices);
            await _db.SaveChangesAsync();
            return dbInvoices;
        }

        public async Task<Invoices?> Get(int id)
        {
            return await _db.Invoices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Invoices?> Update(Invoices invoices)
        {
            var dbInvoices = await Get(invoices.Id);
            if (dbInvoices != null)
            {
                dbInvoices.InvoiceType = invoices.InvoiceType;
                dbInvoices.Descrption = invoices.Descrption;

                await _db.SaveChangesAsync();
                return dbInvoices;
            }
            else
            {
                return null;
            }
        }

        public async Task<Invoices?> Delete(int id)
        {
            var dbInvoices = await Get(id);

            if (dbInvoices != null)
            {
                _db.Invoices.Remove(dbInvoices);
                await _db.SaveChangesAsync();
                return dbInvoices;
            }
            else
            {
                return null;
            }
        }
    }
}
