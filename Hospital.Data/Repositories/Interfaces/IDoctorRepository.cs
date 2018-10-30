namespace Hospital.Data.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Hospital.Models;
    using Hospital.Models.DoctorProcModels;
    using Hospital.Models.ProcModels;
    using Hospital.Models.ViewModels;

    public interface IDoctorRepository
    {
        Task<Doctor> GetByID(int id);

        Task<List<DoctorsYoungerThen>> GetByDob(DateTime dob);

        Task<List<DocsGender>> GetByGender(string gender);

        Task<List<DocGenderYearsSpecialization>> GetByGenderYearsSpecialization(string gender, DateTime date, string Specialization);
    }
}
