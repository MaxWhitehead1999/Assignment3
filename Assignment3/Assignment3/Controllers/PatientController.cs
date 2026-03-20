using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private static List<Patient> ListPatients = new List<Patient>();


        // Create Patient Record
        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            patient.Id = Guid.NewGuid();
            patient.CreationTime = DateTimeOffset.UtcNow;
            patient.UpdatedTime = DateTimeOffset.UtcNow;

            ListPatients.Add(patient);
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.Id }, patient);
        }



        // Recieves a single patient record by id
        [HttpGet("{patientId}")]
        public IActionResult GetPatient(Guid patientId)
        {
            var patient = ListPatients.FirstOrDefault(p => p.Id == patientId);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


        // Updates patient record by patient id
        [HttpPut("{patientId}")]
        public IActionResult UpdatePatient(Guid patientId, [FromBody] Patient patient)
        {
            if (patient == null || patient.Id != patientId)
            {
                return BadRequest();
            }
            var existingPatient = ListPatients.FirstOrDefault(p => p.Id == patientId);
            if (existingPatient == null)
            {
                return NotFound();
            }
            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.UpdatedTime = DateTimeOffset.UtcNow;

            return CreatedAtAction(nameof(GetPatient), new { patientId = existingPatient.Id }, existingPatient);
        }


        // Retrieves all patients that match the first name provided
        [HttpGet]
        public async Task<IActionResult> GetPatientsByFirstName(String FirstName)
        {
            var results = ListPatients
                .Where(p => p.FirstName.Equals(FirstName, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(results);
        }


        // Retreives all the patient that match the last name provided

        [HttpGet]
        public async Task<IActionResult> GetPatientsByLastName(String LastName)
        {
            var results = ListPatients
                .Where(p => p.LastName.Equals(LastName, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(results);
        }



        // Retrieves all patients that match the date of birth provided
        [HttpGet]
        public async Task<IActionResult> GetPatientsByDateOfBirth(DateTime DateOfBirth)
        {
            var results = ListPatients
                .Where(p => p.DateOfBirth.Date == DateOfBirth.Date)
                .ToList();
            return Ok(results);
        }


        // Deletes a patient record by the patient id
        [HttpDelete("{patientId}")]
        public IActionResult DeletePatient(Guid patientId)
        {
            var patient = ListPatients.FirstOrDefault(p => p.Id == patientId);

            if (patient == null)
            {
                return NotFound();
            }

            ListPatients.Remove(patient);

            return NoContent();
        }
    }
}
