using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class PatientController : Controller
    {
        private static List<Patient> patients = new List<Patient>();


        // Create Patient Record
        [HttpPost]
        public IActionResult CreatePatients()
        {
            return Ok(patients);
        }

        // Recieves a single patient record by id
        [HttpGet("{patientId}")]
        public IActionResult GetPatient(Guid patientId)
        {
            var patient = patients.FirstOrDefault(p => p.Id == patientId);

            if patient == null)
            {
                return NotFound();
            }

            return Ok(CreatePatients);
        }


        // Updates patient record by patient id

        [HttpPut("{patientId}")]
        public IActionResult PutPatient(Guid patientId)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            patients.Add(patient);
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.Id }, patient);
        }


        // Retrieves all patients that match the first name provided
        [HttpGet]
        public async Task<IActionResult> GetPatientsByFirstName(String FirstName)
        {
            var results = patients.Where(p => p.FirstName == firstName).ToList();
            return Ok(results);
        }


        // Retreives all the patient that match the last name provided

        [HttpGet]
        public async Task<IActionResult> GetPatientsByLastName(String LastName)
        {
            var results = patients.Where(p => p.LastName == lastName).ToList();
            return Ok(results);
        }

        // Retrieves all patients that match the date of birth provided
        [HttpGet]
        public async Task<IActionResult> GetPatientsByBirth(String DateOfBirth)
        {
            var results = patients.Where(p => p.DateOfBirth == DateOfBirth).ToList();
            return Ok(results);
        }


        // Deletes a patient record by the patient id
        [HttpDelete("{patientId}")]
        public IActionResult DeletePatient(Guid patientId)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            patients.Delete(patient);
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.Id }, patient);
        }
    }
}
