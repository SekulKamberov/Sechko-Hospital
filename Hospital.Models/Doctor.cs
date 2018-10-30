namespace Hospital.Models
{
    using System;

    public class Doctor
    {
        public int DoctorID { get; set; }

        public string DoctorName { get; set; }

        public DateTime Dob { get; set; }

        public string Gender { get; set; }

        public string Specialization { get; set; }

        public int PatientID { get; set; }
    }
}
