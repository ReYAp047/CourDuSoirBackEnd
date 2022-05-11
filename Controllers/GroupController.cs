using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<Group>>> Get()
        {

            return Ok(groups);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group1 = groups.Find(h => h.Id == id);
            if (group1 == null)
                return BadRequest("Group n'exixte pas");

            return Ok(group1);

        }


        [HttpPost]
        public async Task<ActionResult<List<Cours>>> AddGroup(Group group)
        {
            groups.Add(group);
            return Ok(groups);

        }


        [HttpPut]
        public async Task<ActionResult<List<Cours>>> UpdateGroup(Group newGroup)
        {
            var group1 = groups.Find(h => h.Id == newGroup.Id);
            if (group1 == null)
                return BadRequest("Group n'exixte pas");

            group1.Hour = newGroup.Hour;
            group1.GroupSessionNumber = newGroup.GroupSessionNumber;
            group1.GroupLevel = newGroup.GroupLevel;
            group1.NextSessionDate = newGroup.NextSessionDate;
            group1.GroupName = newGroup.GroupName;
            return Ok(groups);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cours>>> Delete(int id)
        {
            var group1 = groups.Find(h => h.Id == id);
            if (group1 == null)
                return BadRequest("Group n'exixte pas");

            groups.Remove(group1);
            return Ok(groups);

        }

    }
}
