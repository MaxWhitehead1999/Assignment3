using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImmunizationController : ControllerBase
    {
        private static List<Immunization> immunizations = new List<Immunization>();

        // Createe Immunization Record
        [HttpPost]
        public IActionResult CreateImmunization([FromBody] Immunization immunization)
        {
            if(immunization == null)
            {
                return BadRequest();
            }

            immunization.ID = Guid.NewGuid();
            immunization.CreationTime = DateTimeOffset.UtcNow;
            immunization.UpdatedTime = DateTimeOffset.UtcNow;

            immunizations.Add(immunization);

            return CreatedAtAction(nameof(GetImmunization), new { ImmunizationId = immunization.ID }, immunization);

        }


        // Recieves a single immunization record by id
        [HttpGet("{immunizationId}")]
        public IActionResult GetImmunization(Guid immunizationId)
        {
            var immunization = immunizations.FirstOrDefault(i => i.Id == immunizationId);

            if (immunization == null)
            {
                return NotFound();
            }

            return Ok(immunization);
        }

        // Retrieves all immunizations that match the Creation Time
        [HttpGet]
        public IActionResult GetByCreationTime(DateTimeOffset CreationTime)
        {
            var iMatchesCT = immunizations.Where(i => i.CreationTime == CreationTime).ToList();
            return Ok(iMatchesCT);
        }


        // Retrieves all immunizations that match the Official Time
        [HttpGet]
        public IActionResult GetByOfficialTime(DateTimeOffset UpdatedTime)
        {
            var iMatchesOT = immunizations.Where(i => i.UpdatedTime == UpdatedTime).ToList();
            return Ok(iMatchesOT);
        }


        // Retrieves all immunizations that match the Trade Name 
        [HttpGet]
        public IActionResult GetByTradeName(string tradeName)
        {
            var iMatchesTD = immunizations.Where(i => i.TradeName == tradeName).ToList();

            return Ok(iMatchesTD);
        }

        // Retrieves all the immunizations that match the name  
        [HttpGet]
        public IActionResult GetByName(string OfficialName)
        {
            var iMatchesN = immunizations.Where(i => i.OfficialName == OfficialName).ToList();
            return Ok(iMatchesN);
        }




        // Updates an immunization record. id must match id provided in PUT request  
        [HttpPut("{ImmunizationId}")]
        public IActionResult UpdateImmunization(Guid ID, [FromBody] Immunization updatedImmunization)
        {
            if (updatedImmunization == null)
            {
                return BadRequest();
            }
            var existingImmunization = immunizations.FirstOrDefault(i => i.Id == updatedImmunization);

            if (existingImmunization == null)
            {
                return NotFound();
            }
            existingImmunization.OfficialName = updatedImmunization.OfficialName;
            existingImmunization.TradeName = updatedImmunization.TradeName;
            existingImmunization.LotNumber = updatedImmunization.LotNumber;
            existingImmunization.ExpirationDate = updatedImmunization.ExpirationDate;
            existingImmunization.UpdatedTime = DateTimeOffset.UtcNow;
            return CreatedAtAction(nameof(GetImmunization), new { ImmunizationId = ID }, existingImmunization);
        }

        // Deletes an immunization record by the immunization id
        [HttpDelete("{ImmunizationId}")]
        public IActionResult DeleteImmunization(Guid immunizationId)
        {
            var immunization = immunizations.FirstOrDefault(i => i.Id == immunizationId);
            if (immunization == null)
            {
                return NotFound();
            }
            immunizations.Remove(immunization);
            return NoContent();
        }
}
