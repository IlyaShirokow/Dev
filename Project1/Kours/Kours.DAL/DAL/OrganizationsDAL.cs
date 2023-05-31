using Kours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{

    public class OrganizationsDAL
    {
        private readonly MVCProductDbContext _db;

        public OrganizationsDAL(DbContextOptions<MVCProductDbContext> db)
        {
            _db = new MVCProductDbContext(db);
        }

        public async Task<List<Domain.Organizations>> GetAll()
        {
            return await _db.Organizations.ToListAsync();

        }

        public async Task<Domain.Organizations> Add(Domain.Organizations newOrganizations)
        {
            var dbOrganizations = new Domain.Organizations()
            {
                Id = newOrganizations.Id,
                NameOrganizations = newOrganizations.NameOrganizations,
                Email = newOrganizations.Email,
                PhoneNumber = newOrganizations.PhoneNumber
            };

            await _db.Organizations.AddAsync(dbOrganizations);
            await _db.SaveChangesAsync();
            return dbOrganizations;
        }

        public async Task<Domain.Organizations?> Get(int id)
        {
            return await _db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Domain.Organizations?> Update(Domain.Organizations organizations)
        {
            var dbOrganizations = await Get(organizations.Id);
            if (dbOrganizations != null)
            {
                dbOrganizations.NameOrganizations = organizations.NameOrganizations;
                dbOrganizations.Email = organizations.Email;
                dbOrganizations.PhoneNumber = organizations.PhoneNumber;

                await _db.SaveChangesAsync();
                return dbOrganizations;
            }
            else
            {
                return null;
            }
        }

        public async Task<Domain.Organizations?> Delete(int id)
        {
            var dbOrganizations = await Get(id);

            if (dbOrganizations != null)
            {
                _db.Organizations.Remove(dbOrganizations);
                await _db.SaveChangesAsync();
                return dbOrganizations;
            }
            else
            {
                return null;
            }
        }
    }
}
