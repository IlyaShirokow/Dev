using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Organizations")]
    [ApiExplorerSettings(GroupName = "organizations")]
    public class OrganizationsController : Controller
    {
        private readonly DAL.DAL.OrganizationsDAL _dal;

        public OrganizationsController(DAL.DAL.OrganizationsDAL organizationsDAL)
        {
            _dal = organizationsDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Organizations>>> GetOrganizations()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Domain.Organizations>> NewOrganizations(Domain.Organizations organizations)
        {
            return await _dal.Add(organizations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Organizations?>> GetOrganizations(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutOrganizations")]
        public async Task<ActionResult<Domain.Organizations?>> PutOrganizations(Domain.Organizations organizations)
        {
            return await _dal.Update(organizations);
        }

        [HttpDelete("DeleteOrganizations/{id}")]
        public async Task<ActionResult<Domain.Organizations?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
