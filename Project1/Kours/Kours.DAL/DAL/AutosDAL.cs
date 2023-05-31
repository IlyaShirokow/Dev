using Kours.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL.DAL
{
    public class AutosDAL
    {
        private readonly MVCProductDbContext _db;

        public AutosDAL(DbContextOptions<MVCProductDbContext> db)
        {
            _db = new MVCProductDbContext(db);
        }

        public async Task<List<Autos>> GetAll()
        {
            return await _db.Autos.ToListAsync();
        }

        public async Task<Autos> Add(Autos newAutos)
        {
            var autos = new Autos()
            {
                Id = newAutos.Id,
                Car = newAutos.Car,
                Carnumber = newAutos.Carnumber,
                Condition = newAutos.Condition
            };

            await _db.Autos.AddAsync(autos);
            await _db.SaveChangesAsync();
            return autos;
        }

        public async Task<Autos?> Get(int id)
        {
            return await _db.Autos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Autos?> Update(Autos autos)
        {
            var dbAutos = await Get(autos.Id);
            if (dbAutos != null)
            {
                dbAutos.Car = autos.Car;
                dbAutos.Carnumber = autos.Carnumber;
                dbAutos.Condition = autos.Condition;

                await _db.SaveChangesAsync();
                return dbAutos;
            }
            else
            {
                return null;
            }
        }

        public async Task<Autos?> Delete(int id)
        {
            var dbAutos = await Get(id);

            if (dbAutos != null)
            {
                _db.Autos.Remove(dbAutos);
                await _db.SaveChangesAsync();
                return dbAutos;
            }
            else
            {
                return null;
            }
        }
    }
}
