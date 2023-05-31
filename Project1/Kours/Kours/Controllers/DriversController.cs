using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Drivers")]
    [ApiExplorerSettings(GroupName = "drivers")]
    public class DriversController : Controller
    {
        private readonly DriversDAL _dal;

        public DriversController(DriversDAL driversDAL)
        {
            _dal = driversDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDrivers()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Drivers>> PostDrivers(Drivers drivers)
        {
            return await _dal.Add(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drivers?>> GetDrivers(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutDrivers")]
        public async Task<ActionResult<Drivers?>> PutDrivers(Drivers drivers)
        {
            return await _dal.Update(drivers);
        }

        [HttpDelete("DeleteDrivers/{id}")]
        public async Task<ActionResult<Drivers?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }

}

