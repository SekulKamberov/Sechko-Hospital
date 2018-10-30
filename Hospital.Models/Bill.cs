namespace Hospital.Models
{
    public class Bill
    {
        public int BillNo { get; set; }

        public decimal Amount { get; set; }

        public int PatientID { get; set; }
    }
}
