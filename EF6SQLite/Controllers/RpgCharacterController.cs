using EF6SQLite.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgCharacterController : ControllerBase{
        private readonly DataContext _context;
        public RpgCharacterController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<RpgCharacter>>>AddCharacter(RpgCharacter character)
        {
            _context.RpgCharacter.Add(character);
            await _context.SaveChangesAsync();
            return Ok(await _context.RpgCharacter.ToListAsync());
        }
         
        [HttpGet]
        public async Task<ActionResult<List<RpgCharacter>>>GetAllCharacter()
        {
            return Ok(await _context.RpgCharacter.ToListAsync());
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<RpgCharacter>>GetCharacter(int id)
        {
            var character = await _context.RpgCharacter.FindAsync(id);
            if(character == null){
                return BadRequest("Character not found.");
            }
            return Ok(character);
        }
        
    }
}