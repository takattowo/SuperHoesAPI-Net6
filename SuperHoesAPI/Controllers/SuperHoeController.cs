using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHoeController : ControllerBase
    {

        private static List<SuperHoe> hoe = new List<SuperHoe>
        {
            new SuperHoe { Address ="test", FirstName= "yes", Id = 1 }
        };

        private readonly DataContext _context;

        public SuperHoeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHoe>>> Get()
        {
            return Ok(await _context.SuperHoes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHoe>> Get(int id)
        {
            var hoae = await _context.SuperHoes.FindAsync(id);
            if (hoae == null)
                return BadRequest("not found");

            return Ok(hoae);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHoe>> AddHoe(SuperHoe ueu)
        {
            _context.SuperHoes.Add(ueu);
            await _context.SaveChangesAsync();
            return Ok(hoe);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHoe>> UpdateHoe(SuperHoe request)
        {
            var hoae = await _context.SuperHoes.FindAsync(request.Id);
            if (hoae == null)
                return BadRequest("not found");

            hoae.Address = request.Address;
            hoae.FirstName = request.FirstName;
            hoae.LastName = request.LastName;
            hoae.Name = request.Name;

            _context.SuperHoes.Update(hoae);
            await _context.SaveChangesAsync();

            return Ok(hoae);  
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHoe>> Delete(int id)
        {
            var hoae = await _context.SuperHoes.FindAsync(id);
            if (hoae == null)
                return BadRequest("not found");

            _context.SuperHoes.Remove(hoae);
            await _context.SaveChangesAsync();

            return Ok(hoae);
        }
    }
}
