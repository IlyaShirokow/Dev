using Kours.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL.DAL
{
    public class ProductsDAL
    {
        private readonly MVCProductDbContext _db;

        public ProductsDAL(DbContextOptions<MVCProductDbContext> db)
        {
            _db = new MVCProductDbContext(db);
        }

        public async Task<List<Products>> GetAll()
        {
            return await _db.Products.ToListAsync();

        }

        public async Task<Products> Add(Products newProducts)
        {
            var dbProducts = new Products()
            {
                Id = newProducts.Id,
                Product = newProducts.Product,
                Fragility = newProducts.Fragility,
                Dimension = newProducts.Dimension
            };

            await _db.Products.AddAsync(dbProducts);
            await _db.SaveChangesAsync();
            return dbProducts;
        }

        public async Task<Products?> Get(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Products?> Update(Products products)
        {
            var dbProducts = await Get(products.Id);
            if (dbProducts != null)
            {
                dbProducts.Product = products.Product;
                dbProducts.Fragility = products.Fragility;
                dbProducts.Dimension = products.Dimension;

                await _db.SaveChangesAsync();
                return dbProducts;
            }
            else
            {
                return null;
            }
        }

        public async Task<Products?> Delete(int id)
        {
            var dbProducts = await Get(id);

            if (dbProducts != null)
            {
                _db.Products.Remove(dbProducts);
                await _db.SaveChangesAsync();
                return dbProducts;
            }
            else
            {
                return null;
            }
        }
    }
}
