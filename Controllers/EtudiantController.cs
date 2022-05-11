using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourDuSoirBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {

        private static List<Etudiant> etudiants = new List<Etudiant>
            {
                new Etudiant
                {
                    Id = 1,
                    Name = "Dali",
                    EntryDate = "05/11/2022",
                    Group = "First year A",
                    Level = "1er",
                    NumberOfSessions = 0,
                    Payment = true,
                    PhoneNumber = 20111111
                },
                new Etudiant
                {
                    Id = 2,
                    Name = "Foulen",
                    EntryDate = "05/11/2022",
                    Group = "Seconde year A",
                    Level = "2er",
                    NumberOfSessions = 1,
                    Payment = true,
                    PhoneNumber = 20111111
                }
            };

        [HttpGet]
        public async Task<ActionResult< List<Etudiant> > > Get()
        {

            return Ok(etudiants);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> Get(int id)
        {
            var etudiant1 = etudiants.Find(h => h.Id == id);
            if (etudiant1 == null)
                return BadRequest("Etudiant n'exixte pas");

            return Ok(etudiant1);

        }

        [HttpPost]
        public async Task<ActionResult<List<Cours>>> AddEtudiant(Etudiant etudiant)
        {
            etudiants.Add(etudiant);
            return Ok(etudiants);

        }

        [HttpPut]
        public async Task<ActionResult<List<Etudiant>>> UpdateEtudiant(Etudiant newEtudiant)
        {
            var etudiant1 = etudiants.Find(h => h.Id == newEtudiant.Id);
            if (etudiant1 == null)
                return BadRequest("Etudiant n'exixte pas");

            etudiant1.Name = newEtudiant.Name;
            etudiant1.EntryDate = newEtudiant.EntryDate;
            etudiant1.Group = newEtudiant.Group;
            etudiant1.Level = newEtudiant.Level;
            etudiant1.NumberOfSessions = newEtudiant.NumberOfSessions;
            etudiant1.Payment = newEtudiant.Payment;
            etudiant1.PhoneNumber = newEtudiant.PhoneNumber;

            return Ok(etudiants);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Etudiant>>> Delete(int id)
        {
            var etudiant1 = etudiants.Find(h => h.Id == id);
            if (etudiant1 == null)
                return BadRequest("Etudiant n'exixte pas");

            etudiants.Remove(etudiant1);
            return Ok(etudiants);

        }

    }
}
