namespace Hospital.Data.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Hospital.Models;
    using Hospital.Models.PatientProcModels;
    using Hospital.Models.ProcModels;
    using Hospital.Models.ViewModels;

    public interface IPatientRepository
    {
        Task<Patient> GetByID(int id);

        Task<List<Patient>> GetByDateOfBirth(DateTime dateOfBirth);

        Task<List<ReleasePatient>> ReleasePatient(int patientID);

        Task<List<PatientsGender>> GetPatientsByGender(string gender);

        Task<int> AllDays();
    }
}
