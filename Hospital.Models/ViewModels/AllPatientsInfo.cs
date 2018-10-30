using System;

namespace Hospital.Models.ViewModels
{
    public class AllPatientsInfo
    {
        public Patient Patient { get; set; }

        //public string Gender { get; set; }

        //public DateTime Dob { get; set; }

        //public DateTime AdmitDate { get; set; }

        //public DateTime ReleaseDate { get; set; }

        public Room Room { get; set; }

        public Nurse Nurse { get; set; }

        public Receptionist Receptionist { get; set; }

        public Doctor Doctor { get; set; }

        //public string Specialization { get; set; }

        public Medicine Medicine { get; set; }   

        //public int Quantity { get; set; }

        //public int price { get; set; }
    }
}
