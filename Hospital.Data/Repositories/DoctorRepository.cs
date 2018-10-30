namespace Hospital.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    using Microsoft.Extensions.Configuration;

    using Hospital.Data.Repositories.Interfaces;
    using Hospital.Models;
    using Dapper;
    using System.Linq;
    using System.Threading.Tasks;
    using Hospital.Models.DoctorProcModels;

    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration config;

        public DoctorRepository(IConfiguration configuration)
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

        public async Task<Doctor> GetByID(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT doctorID, doctorName, Dob, gender, specialization, patientID FROM Doctor WHERE doctorID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<Doctor>(sQuery, new { ID = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<DoctorsYoungerThen>> GetByDob(DateTime dob) 
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<DoctorsYoungerThen>("usp_DoctorsYoungerThen", new { dob = @dob }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<DocsGender>> GetByGender(string gender)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<DocsGender>("usp_DoctorsByGender", new { gender = @gender }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<DocGenderYearsSpecialization>> GetByGenderYearsSpecialization(string gender, DateTime date, string Specialization )
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<DocGenderYearsSpecialization>("usp_DocGenderYearsSpecialization", new { gender = @gender, Dob = @date, Specialization = @Specialization }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
