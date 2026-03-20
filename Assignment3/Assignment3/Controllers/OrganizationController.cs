using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {

        private static List<Organization> organizationList = new List<Organization>();

        // Create Organization Record
        [HttpPost]
        public IActionResult CreateOrganization([FromBody] Organization organization)
        {
            if (organization == null)
            {
                return BadRequest();
            }

            organization.Id = Guid.NewGuid();
            organization.CreationTime = DateTimeOffset.UtcNow;
            organization.UpdatedTime = DateTimeOffset.UtcNow;

            organizationList.Add(organization);

            return CreatedAtAction(nameof(GetOrganization),
                new { organizationId = organization.Id },
                organization);
        }


        // Recieves a single organization record by id
        [HttpGet("{OrganizationId}")]
        public IActionResult GetOrganization(Guid OrganizationId)
        {
            var organization = organizationList.FirstOrDefault(o => o.Id == OrganizationId);
            if (organization == null)
            {
                return NotFound();
            }
            return Ok(organization);
        }


        // Updates organization record. id must match id provided in PUT request
        [HttpPut("{OrganizationId}")]
        public IActionResult UpdateOrganization(Guid OrganizationId, [FromBody] Organization organization)
        {
            if (organization == null || organization.Id != OrganizationId)
            {
                return BadRequest();
            }
            var existingOrganization = organizationList.FirstOrDefault(o => o.Id == OrganizationId);
            if (existingOrganization == null)
            {
                return NotFound();
            }
            existingOrganization.Name = organization.Name;
            existingOrganization.Type = organization.Type;
            existingOrganization.Address = organization.Address;
            existingOrganization.UpdatedTime = DateTimeOffset.UtcNow;

            return Ok(existingOrganization);
        }

        // Retrieves all organization data that match the name provided 
        [HttpGet]
        public IActionResult GetOrganizationByName(string name)
        {
            var MatchesName= organizationList.Where(o => o.Name == name).ToList();
            
            return Ok(MatchesName);
        }



        // Retreives all the data that match the type provided
        [HttpGet]
        public IActionResult GetOrganizationByType(string type)
        {
            var matches = organizationList
                .Where(o => o.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(matches);
        }

        //Detetes an organization record using the organization id

        [HttpDelete("{organizationId}")]
        public IActionResult DeleteOrganization(Guid organizationId)
        {
            var organization = organizationList.FirstOrDefault(o => o.Id == organizationId);

            if (organization == null)
            {
                return NotFound();
            }

            organizationList.Remove(organization);

            return NoContent();
        }
    }
}
