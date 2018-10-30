namespace Hospital.Models
{
    public class Medicine
    {
        public int MedicineCode { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int PatientID { get; set; }
    }
}
