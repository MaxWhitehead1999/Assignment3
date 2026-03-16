using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class ImmunizationController : Controller
    {
        private static List<Immunization> Immunization = new List<Immunization>();


        // Createe Immunization Record
        [HttpPost]                                  
        public IActionResult CreateImmunization)
        {
            return Ok(Immunization);
        }


        // Recieves a single immunization record by id
        [HttpGet("{ImmunizationId}")]
        public IActionResult GetImmunization(Guid ImmunizationId)
        {
            var Immunization = Immunization.FirstOrDefault(p => p.Id == ImmunizationId);

            if Immunization == null)
            {
                return NotFound();
            }

            return Ok(Immunization);
        }

        // Retrieves all immunizations that match the Creation Time
        [HttpGet]

        // Retrieves all immunizations that match the Official Time
        [HttpGet]

        // Retrieves all immunizations that match the Trade Name 
        [HttpGet]

        // Retrieves all the immunizations that match the name  
        [HttpGet]

        // Updates an immunization record. id must match id provided in PUT request  
        [HttpPut("{ImmunizationId}")]

        // Deletes an immunization record by the immunization id
        [HttpDelete("{ImmunizationId}")]
        public IActionResult DeleteImmunization(Guid ImmunizationId)
        {
            if (ImmunizationId == null)
            {
                return BadRequest();
            }
            Organization.Delete(ImmunizationId);
            return CreatedAtAction(nameof(GetImmunization), new { ImmunizationId = Immunization.Id }, Immunization);
        }


    }
}
