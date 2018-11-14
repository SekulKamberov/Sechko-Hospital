namespace Hospital.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Dapper;
    using Hospital.Models;
    using Hospital.Data.Repositories.Interfaces;
 
    using Hospital.Models.ProcModels;
    using Hospital.Models.PatientProcModels;

    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration config;

        public PatientRepository(IConfiguration configuration)
        {
            config = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("MyConnectionString"));
            }
        }

        public async Task<Patient> GetByID(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT patientID, patientName, Dob, gender, admitDate, releaseDate, receptionistID FROM Patient WHERE patientID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<Patient>(sQuery, new { ID = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Patient>> GetByDateOfBirth(DateTime admitDate)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT patientID, patientName, Dob, gender, admitDate, releaseDate, receptionistID FROM Patient WHERE AdmitDate = @Admit";
                conn.Open();
                var result = await conn.QueryAsync<Patient>(sQuery, new { Admit = admitDate });
                return result.ToList();
            }
        }

        public async Task<List<ReleasePatient>> ReleasePatient(int patientID)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var patient = await conn.QueryAsync<ReleasePatient>(Constants.ReleasePatient, new { patientID = patientID }, commandType: CommandType.StoredProcedure);
                return patient.ToList(); 
            }
        }

        //NO MAGIC STRINGS TO CREATE CONSTANTS CLASS!
        public async Task<List<PatientsGender>> GetPatientsByGender(string gender)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<PatientsGender>(Constants.USP_PatientsByGender, new { gender = @gender }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<int> AllDays()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var patient = await conn.QueryAsync<int>(Constants.AllPatientDays);
                return patient.FirstOrDefault(); 
            }
        }
    }
}

