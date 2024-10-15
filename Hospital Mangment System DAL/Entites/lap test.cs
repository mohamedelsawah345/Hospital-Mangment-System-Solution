using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Lap_test
    {
        [Key]
        public int Test_ID { get; set; }
        public string Test_name { get; set; }
        public int Dr_id { get; set; }
        public Doctor doctor { get; set; }
        public bool? IsDeleted { get; set; }
        public int Patient_ID { get; set; }
        public Patient patient { get; set; }
    }
}
