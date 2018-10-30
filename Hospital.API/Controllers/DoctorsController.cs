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
    using Hospital.Models.DoctorProcModels;

    public class DoctorsController : BaseApiController
    {
        private readonly IDoctorRepository doctorRepo;

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            doctorRepo = doctorRepository;
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult<Doctor>> GetByID(int id)
        {
            return await doctorRepo.GetByID(id);
        }

        [HttpGet]
        [Route("dob/{dob:datetime}")]
        public async Task<ActionResult<List<DoctorsYoungerThen>>> DoctorsYoungerThen(DateTime dob)
        {
            return await doctorRepo.GetByDob(dob);
        }

        [HttpGet]
        [Route("gender/{gender}")]
        public async Task<ActionResult<List<DocsGender>>> GetByGender(string gender)
        {
            return await doctorRepo.GetByGender(gender);
        }

        [HttpGet]
        [Route("doctor/{gender}/{date:datetime}/{specialization}")]
        public async Task<ActionResult<List<DocGenderYearsSpecialization>>> GetDocGenderYearsSpecialization (string gender, DateTime date, string specialization)
        {
            return await doctorRepo.GetByGenderYearsSpecialization(gender, date, specialization);
        }
    }
}
