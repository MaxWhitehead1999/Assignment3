using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class OrganizationController : Controller
    {

        private static List<Organization> createOrganization = new List<Patient>();

        // Create Organization Record
        [HttpPost]                                  
        public IActionResult GetOrganization()
        {
            return Ok(createOrganization);
        }

        // Recieves a single organization record by id
        [HttpGet("{OrganizationId}")]
        public IActionResult GetOrganization(Guid OrganizationId)
        {
            var Orginaization = Orginaization.FirstOrDefault(p => p.Id == OrginizationId);

            if Orginaization == null)
            {
                return NotFound();
            }

            return Ok(Orginaization);
        }

        // Updates organization record. id must match id provided in PUT request
        [HttpPut("{OrganizationId}")]
        public IActionResult UpdateOrganization(Guid OrganizationId)
        {

        }

        // Retrieves all organization data that match the name provided 

        [HttpGet]


        // Retreives all the data that match the type provided

        [HttpGet]

        //Detetes an organization record using the organization id

        [HttpDelete("{OrganizationId}")]
        public IActionResult DeleteOrganization(Guid OrganizationId)
        {
            if (OrganizationId == null)
            {
                return BadRequest();
            }
            Organization.Delete(OrganizationId);
            return CreatedAtAction(nameof(GetOrganization), new { OrginizationId = Organization.Id }, Orginization);
        }
    }
}
