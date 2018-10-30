namespace Hospital.API.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    using Hospital.Models;
    using Hospital.Data.Repositories.Interfaces;
    using Hospital.Models.ViewModels;
    using Hospital.Models.ProcModels;
    using Hospital.Models.PatientProcModels;

    public class PatientsController : BaseApiController
    {
        private readonly IPatientRepository patientRepo;

        public PatientsController(IPatientRepository patientsRepo)
        {
            patientRepo = patientsRepo;
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult<Patient>> GetByID(int id)
        {
            return await patientRepo.GetByID(id);
        }
        
        [HttpGet]
        [Route("admitDate/{admitDate:datetime}")]
        public async Task<ActionResult<List<Patient>>> GetByAdmit(DateTime admitDate)
        {
            return await patientRepo.GetByDateOfBirth(admitDate);
        }

        [HttpGet]
        [Route("releasePatient/{id:int:min(1)}")]
        public async Task<ActionResult<List<ReleasePatient>>> ReleasePatient(int id)
        {
            return await patientRepo.ReleasePatient(id);
        }

        [HttpGet]
        [Route("gender/{gender}")]
        public async Task<ActionResult<List<PatientsGender>>> PatientsByGender(string gender)
        {
            return await patientRepo.GetPatientsByGender(gender);
        }

        [HttpGet]
        [Route("TotalDays/")]
        public async Task<ActionResult<int>> TotalDays()
        {
            return await patientRepo.AllDays();
        }
    }
}
