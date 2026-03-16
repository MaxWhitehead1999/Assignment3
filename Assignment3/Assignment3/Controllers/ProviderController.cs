using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    public class PrfoviderController : Controller
    {

        private static List<Patient> Provider = new List<Provider>();

        // Create Provider Record

        [HttpPost]
        public IActionResult CreateProvider([Provider provider)
        {
            if (provider == null)
            {
                return BadRequest();
            }

            provider.Id = Guid.NewGuid();
            provider.CreationTime = DateTimeOffset.UtcNow;

            providers.Add(provider);

            return CreatedAtAction(nameof(GetProvider), new { providerId = provider.Id }, provider);
        }

        // Recieves a single provider record by id

        [HttpGet("{Providerid}")]

        public IActionResult getProvider(Guid Providerid)
        {
            if (Provider == null)
            {
                return BadRequest();
            }
            Provider.Add(Provider);
            return CreatedAtAction(nameof(GetProvider), new { providerId = Provider.Id }, Provider);
        }


        // Updates provider record by provider id

        [HttpPut("{providerId}")]
        public IActionResult UpdateProvider(Guid providerId)
        {
            if (provider == null)
            {
                return BadRequest();
            }
            provider.Add(providerId);

            return CreatedAtAction(nameof(GetProvider), new { providerId = provider.Id }, provider);
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