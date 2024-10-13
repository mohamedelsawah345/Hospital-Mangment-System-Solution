
using System.ComponentModel.DataAnnotations;


namespace Hospital_Mangment_System_DAL.Entites
{
    public class Addmission
    {
        [Key]
        public int Addmission_Id { get; set; }
        public int room_number { get; set; }
        public DateOnly Addmission_Date { get; set; }
        public DateOnly Date_discharge { get; set; }
        public int Patient_Id { get; set; }

        public Patient patient { get; set; } = null;//ameend test
    }
}
