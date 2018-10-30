namespace Hospital.Models
{
    public class Room
    {
        public int RoomID { get; set; }

        public string RoomType { get; set; }

        public string Status { get; set; }

        public int PatientID { get; set; }
    }
}
