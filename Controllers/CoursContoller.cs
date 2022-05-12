using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly DataContext _context;
        public CoursContoller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cours>>> Get()
        {

            return Ok(await _context.Courses.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cours>> Get(int id)
        {
            var cour = await _context.Courses.FindAsync(id);
            if (cour == null)
                return BadRequest("Cour n'exixte pas");

            return Ok(cour);

        }


        [HttpPost]
        public async Task<ActionResult<List<Cours>>> AddCours(Cours cour) 
        {
            _context.Courses.Add(cour);
            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());

        }


        [HttpPut]
        public async Task<ActionResult<List<Cours>>> UpdateCours(Cours newCours)
        {
            var cour = await _context.Courses.FindAsync(newCours.Id);
            if (cour == null)
                return BadRequest("Cour n'exixte pas");

            cour.CourseLevel = newCours.CourseLevel;
            cour.CourseName = newCours.CourseName;
            cour.FileUrl = newCours.FileUrl;

            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cours>>> Delete(int id)
        {
            var cour = await _context.Courses.FindAsync(id);
            if (cour == null)
                return BadRequest("Cour n'exixte pas");

             _context.Courses.Remove(cour);

            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());

        }

    }
}
