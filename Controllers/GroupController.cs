using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourDuSoirBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private static List<Group> groups = new List<Group>
            {
                new Group
                {
                    Id = 1,
                    GroupName = "Groupe 1er A",
                    GroupLevel = "1er",
                    GroupSessionNumber = 0,
                    Hour = "17h",
                    NextSessionDate = "11/11/2022"
                },
                new Group
                {
                    Id = 2,
                    GroupName = "Groupe 2eme A",
                    GroupLevel = "2eme",
                    GroupSessionNumber = 0,
                    Hour = "19h",
                    NextSessionDate = "11/11/2022"
                }
            };
        private readonly DataContext _context;
        public GroupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> Get()
        {

            return Ok(await _context.Groups.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group1 = await _context.Groups.FindAsync(id);
            if (group1 == null)
                return BadRequest("Group n'exixte pas");

            return Ok(group1);

        }


        [HttpPost]
        public async Task<ActionResult<List<Cours>>> AddGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return Ok(await _context.Groups.ToListAsync());

        }


        [HttpPut]
        public async Task<ActionResult<List<Cours>>> UpdateGroup(Group newGroup)
        {
            var group1 = await _context.Groups.FindAsync(newGroup.Id);
            if (group1 == null)
                return BadRequest("Group n'exixte pas");

            group1.Hour = newGroup.Hour;
            group1.GroupSessionNumber = newGroup.GroupSessionNumber;
            group1.GroupLevel = newGroup.GroupLevel;
            group1.NextSessionDate = newGroup.NextSessionDate;
            group1.GroupName = newGroup.GroupName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Groups.ToListAsync());

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cours>>> Delete(int id)
        {
            var group1 = await _context.Groups.FindAsync(id);
            if (group1 == null)
                return BadRequest("Group n'exixte pas");

            _context.Groups.Remove(group1);

            await _context.SaveChangesAsync();

            return Ok(await _context.Groups.ToListAsync());

        }

    }
}
