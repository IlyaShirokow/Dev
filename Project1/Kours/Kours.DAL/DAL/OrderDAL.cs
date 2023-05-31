using Kours.Domain;
using Kours.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{
    public class OrderDAL
    {
        private readonly MVCProductDbContext _db;

        public OrderDAL(DbContextOptions<MVCProductDbContext> db)
        {
            _db = new MVCProductDbContext(db);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _db.Order.ToListAsync();

        }

        public async Task<Order> Add(Order newOrder)
        {
            var dbOrder = new Order()
            {
                Id = newOrder.Id,
                ProductsID = newOrder.ProductsID,
                AutosID = newOrder.AutosID,
                DriversId = newOrder.DriversId,
                OrganizationsId = newOrder.OrganizationsId,
                PhoneNumber = newOrder.PhoneNumber,
                Address = newOrder.Address,
                Data = newOrder.Data,
                Email = newOrder.Email,
                InvoicesId = newOrder.InvoicesId
            };

            await _db.Order.AddAsync(dbOrder);
            await _db.SaveChangesAsync();
            return dbOrder;
        }

        public async Task<Order?> Get(int id)
        {
            return await _db.Order.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order?> Update(Order order)
        {
            var dbOrder = await Get(order.Id);
            if (dbOrder != null)
            {
                dbOrder.ProductsID = order.ProductsID;
                dbOrder.AutosID = order.AutosID;
                dbOrder.DriversId = order.DriversId;
                dbOrder.OrganizationsId = order.OrganizationsId;
                dbOrder.PhoneNumber = order.PhoneNumber;
                dbOrder.Address = order.Address;
                dbOrder.Data = order.Data;
                dbOrder.Email = order.Email;
                dbOrder.InvoicesId = order.InvoicesId;

                await _db.SaveChangesAsync();
                return dbOrder;
            }
            else
            {
                return null;
            }
        }

        public async Task<Order?> Delete(int id)
        {
            var dbOrder = await Get(id);

            if (dbOrder != null)
            {
                _db.Order.Remove(dbOrder);
                await _db.SaveChangesAsync();
                return dbOrder;
            }
            else
            {
                return null;
            }
        }
    }
}
