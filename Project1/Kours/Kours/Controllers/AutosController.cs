using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Autos")]
    [ApiExplorerSettings(GroupName = "autos")]
    public class AutosController : Controller
    {
        private readonly AutosDAL _dal;

        public AutosController(AutosDAL autosDAL)
        {
            _dal = autosDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autos>>> GetAutos()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Autos>> PostAutos(Autos autos)
        {
            return await _dal.Add(autos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autos?>> GetAutos(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutAutos")]
        public async Task<ActionResult<Autos?>> PutAutos(Autos model)
        {
            return await _dal.Update(model);
        }

        [HttpDelete("DeleteAutos/{id}")]
        public async Task<ActionResult<Autos?>> Delete(int id)
        {
             return await _dal.Delete(id);
        }
    }

}

