namespace Hospital.Models
{
    using System;

    public class Patient
    {
        public int patientID { get; set; }

        public string patientName { get; set; }

        public DateTime Dob { get; set; }

        public string gender { get; set; }

        public DateTime AdmitDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ReceptionistID { get; set; }
    }
}
