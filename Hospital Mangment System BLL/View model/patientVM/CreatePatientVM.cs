using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.patientVM
{
    public  class CreatePatientVM
    {

        public string Id { get; set; } // This will be the ApplicationUserId
        [Required]
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; } // Patient-specific

        [Required]
        public string Gender { get; set; } // Patient-specific
    }
}
