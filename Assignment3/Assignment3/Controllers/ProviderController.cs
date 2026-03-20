using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private static List<Provider> ListProviders = new List<Provider>();

        // Create Provider Record 
        [HttpPost]
        public IActionResult CreateProvider([FromBody] Provider provider)
        {
            if(provider == null)
            {
                return BadRequest();
            }
            provider.Id = Guid.NewGuid();
            provider.CreationTime = DateTimeOffset.UtcNow;
            provider.UpdatedTime = DateTimeOffset.UtcNow;

            ListProviders.Add(provider);

            return CreatedAtAction(nameof(GetProvider), new { providerId = provider.Id }, provider);
        }


        // Recieves a single provider record by id
        [HttpGet("{Providerid}")]
        public IActionResult GetProvider(Guid patientId)
        {
            var patient = ListProviders.FirstOrDefault(p => p.Id == patientId);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // Updates provider record by provider id
        [HttpPut("{providerId}")]
        public IActionResult UpdateProvider(Guid providerId, [FromBody] Provider updatedProvider) {
            if (updatedProvider == null) {
                return BadRequest();
            }

            var existingProvider = ListProviders.FirstOrDefault(p => p.Id == providerId);

            if (existingProvider == null)
            {
                return NotFound();
            }

            existingProvider.FirstName = UpdateProvider.FirstName;
            existingProvider.LastName = UpdateProvider.LastName;
            existingProvider.Address = UpdateProvider.Address;
            existingProvider.LicenseNumber = UpdateProvider.LicenseNumber;
            existingProvider.OrganizationName = UpdateProvider.OrganizationName;
            existingProvider.UpdatedTime = DateTimeOffset.UtcNow;

            return Ok(existingProvider);
        }

        


        // Retrieves all providers that match the first name provided

        [HttpGet]
        public async Task<IActionResult> GetProviderByPatientFirstName(String FirstName)
        {
            var results = Provider.Where(p => p.FirstName == FirstName).ToList();
            return Ok(results);
        }

        // Retreives all the provider that match the last name provided

        [HttpGet]
        public async Task<IActionResult> GetProviderByPatientLastName(String LastName)
        {
            var results = Provider.Where(p => p.LastName == LastName).ToList();
            return Ok(results);
        }

        // Retreives all the provider that match the licence Number provided

        [HttpGet]

        public async Task<IActionResult> ProviderLicenceNumber(String LicenceNumber)
        {
            var results = Provider.Where(p => p.DateOfBirth == DateOfBirth).ToList();
            return Ok(results); ByOrganization
        }

        // Retreives all the provider that match the organization provided

        [HttpDelete("{providerId}")]
        public IActionResult DeletePatient(Guid providerId)
        {
            if (provider == null)
            {
                return BadRequest();
            }
            provider.Delete(provider);
            return CreatedAtAction(nameof(GetProvider), new { providerId = provider.Id }, provider);
        }

    }
}