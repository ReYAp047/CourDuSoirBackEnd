using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourDuSoirBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursContoller : ControllerBase
    {

        private static List<Cours> coures = new List<Cours>
            {
                new Cours
                {
                    Id = 1,
                    CourseLevel = "1er",
                    CourseName = "Cahpitre 1 Math",
                    FileUrl ="aaa"
                },
                new Cours
                {
                    Id = 2,
                    CourseLevel = "2eme",
                    CourseName = "Cahpitre 1 Algorithme",
                    FileUrl ="bbb"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Cours>>> Get()
        {

            return Ok(coures);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cours>> Get(int id)
        {
            var cour = coures.Find(h => h.Id == id);
            if (cour == null)
                return BadRequest("Cour n'exixte pas");

            return Ok(cour);

        }


        [HttpPost]
        public async Task<ActionResult<List<Cours>>> AddCours(Cours cour) 
        {    
            coures.Add(cour);
            return Ok(coures);

        }


        [HttpPut]
        public async Task<ActionResult<List<Cours>>> UpdateCours(Cours newCours)
        {
            var cour = coures.Find(h => h.Id == newCours.Id);
            if (cour == null)
                return BadRequest("Cour n'exixte pas");

            cour.CourseLevel = newCours.CourseLevel;
            cour.CourseName = newCours.CourseName;
            cour.FileUrl = newCours.FileUrl;

            return Ok(coures);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cours>>> Delete(int id)
        {
            var cour = coures.Find(h => h.Id == id);
            if (cour == null)
                return BadRequest("Cour n'exixte pas");

            coures.Remove(cour);
            return Ok(coures);

        }

    }
}
