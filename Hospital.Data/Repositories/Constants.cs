namespace Hospital.Data.Repositories
{
    public class Constants
    {
        //Patient
        public const string ReleasePatient = "releasePatient";
        public const string AllPatientDays = "allPatientDays";

        //User stored procedures
        public const string USP_PatientsByGender = "usp_PatientsByGender";


        //Doctor
        public const string USP_DoctorsByGender = "usp_DoctorsByGender";
        public const string USP_DoctorsYoungerThen = "usp_DoctorsYoungerThen";
        public const string USP_DocGenderYearsSpecialization = "usp_DocGenderYearsSpecialization";
    }
}
