using Kours.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL.DAL
{
    public class DriversDAL
    {
        private readonly MVCProductDbContext _db;

        public DriversDAL(DbContextOptions<MVCProductDbContext> db)
        {
            _db = new MVCProductDbContext(db);
        }

        public async Task<List<Drivers>> GetAll()
        {
            return await _db.Drivers.ToListAsync();

        }

        public async Task<Drivers> Add(Drivers newDrivers)
        {
            var dbDrivers = new Drivers()
            {
                Id = newDrivers.Id,
                Surname = newDrivers.Surname,
                Name = newDrivers.Name,
                PhoneNumber = newDrivers.PhoneNumber,
                Email = newDrivers.Email,
                Address = newDrivers.Address,
                DateOfBirth = newDrivers.DateOfBirth
            };

            await _db.Drivers.AddAsync(dbDrivers);
            await _db.SaveChangesAsync();
            return dbDrivers;
        }

        public async Task<Drivers?> Get(int id)
        {
            return await _db.Drivers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Drivers?> Update(Drivers drivers)
        {
            var dbDrivers = await Get(drivers.Id);
            if (dbDrivers != null)
            {
                dbDrivers.Surname = drivers.Surname;
                dbDrivers.Name = drivers.Name;
                dbDrivers.PhoneNumber = drivers.PhoneNumber;
                dbDrivers.Email = drivers.Email;
                dbDrivers.Address = drivers.Address;
                dbDrivers.DateOfBirth = drivers.DateOfBirth;

                await _db.SaveChangesAsync();
                return dbDrivers;
            }
            else
            {
                return null;
            }
        }

        public async Task<Drivers?> Delete(int id)
        {
            var dbDrivers = await Get(id);

            if (dbDrivers != null)
            {
                _db.Drivers.Remove(dbDrivers);
                await _db.SaveChangesAsync();
                return dbDrivers;
            }
            else
            {
                return null;
            }
        }
    }
}
